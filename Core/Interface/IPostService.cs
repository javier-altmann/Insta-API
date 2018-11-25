using Core.DTO;

namespace Core.Interface
{
    public interface IPostService
    {
        Post Post(Post post);
        void Get(int afterId);    
    }
}