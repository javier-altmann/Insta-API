using System;
using System.Collections.Generic;
using System.Linq;
using Core.DTO;
using Core.Interface;
using DAL;

namespace Core.Services {
    public class PostService : IPostService {
        private ApiDbContext context;
        public PostService (ApiDbContext context) {
            this.context = context;
        }

        public void Get (int afterId) {
            throw new System.NotImplementedException ();
        }

        public DTO.Post Post (DTO.Post post) {
            try {
                var parsePost = new DAL.Post {
                    CreatedAt = post.CreatedAt,
                    Description = post.Description,
                    ImageSource = post.ImageSource,
                    Latitud = post.Latitud,
                    Longitud = post.Longitud
                };

                context.Posts.Add(parsePost);

                var hastagsList = context.Hashtags.ToList();

                foreach (var hashtag in hastagsList) {
                    var validateDescription = post.Description.Contains(hashtag.Name);
                    if (validateDescription) {
                        var id = context.Hashtags.Where (x => x.Name == hashtag.Name).Select(y => y.Id).First();
                        
                        var postHashtag = new DAL.PostHashtags {
                            PostId = parsePost.Id,
                            HashtagId = id
                        };

                        context.PostHastags.Add(postHashtag);
                    }
                }
                
                context.SaveChanges();                

                return post;
            } catch (Exception ex) {
                throw new Exception ("Error al insertar el post " + ex);
            }
        }
    }
}

/*
data: [
        {
            hashtag: 'COMIDA',
            posts: [
                {
                    "User": "@micaela"
                    "CreatedAt": "01/11/2018 00:00:00",
                    "Description": "Decription test",
                    "ImageSource": "image.png",
                    "Latitud": "2323232",
                    "Longitud": "1212111"
                },
                {
                    "User": "@sara"
                    "CreatedAt": "01/11/2018 00:00:00",
                    "Description": "Decription test",
                    "ImageSource": "image.png",
                    "Latitud": "2323232",
                    "Longitud": "1212111"
                }
            ]
        },
        {
            hashtag: 'MEDICAMENTOS',
            posts: [
                {
                    "User": "@jose"
                    "CreatedAt": "01/11/2018 00:00:00",
                    "Description": "Decription test",
                    "ImageSource": "image.png",
                    "Latitud": "2323232",
                    "Longitud": "1212111"
                },
                {
                    "User": "@miguel"
                    "CreatedAt": "01/11/2018 00:00:00",
                    "Description": "Decription test",
                    "ImageSource": "image.png",
                    "Latitud": "2323232",
                    "Longitud": "1212111"
                }
            ]
        }
            ]
        }

 */