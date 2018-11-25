using System.Collections.Generic;
using System.Linq;
using Core.DTO;
using Core.Interface;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace Core.Services {
    public class HashtagService : IHashtagService {
        private ApiDbContext context;
        public HashtagService (ApiDbContext context) {
            this.context = context;
        }
        public List<DTO.Hashtag> Get() {
            try {
                var hashtagList = context.PostHastags.Include(x=> x.Hashtag).
                GroupBy(x => new {
                    x.Hashtag.Name
                })
                .Select (x => new DTO.Hashtag {
                    Name = x.Key.Name,
                    Count = x.Count()
                }).ToList ();

                return hashtagList;
            } catch (System.Exception ex) {

                throw new System.Exception ("Ocurrio un error al hacer el request");
            }
        }
        
    }
}