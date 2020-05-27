using System.Net.Http;
using System.Threading.Tasks;
using FilmWebAPI.Core.Abstraction;

namespace FilmWebAPI.Core.Communication
{
    public abstract class ContentRequestBase<TEntity> : RequestBase<TEntity>
    {

        protected ContentRequestBase() { }

        protected ContentRequestBase(ISignature signature, FilmWebHttpMethod filmWebHttpMethod) : base(signature, filmWebHttpMethod)
        {
        }

        public override async Task<TEntity> Parse(HttpResponseMessage responseMessage)
        {
            var content = await GetRawBody(responseMessage).ConfigureAwait(false);
            return await Parse(content).ConfigureAwait(false);
        }

        public abstract Task<TEntity> Parse(string content);
    }
}