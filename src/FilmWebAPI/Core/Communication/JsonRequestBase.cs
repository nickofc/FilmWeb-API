using FilmWebAPI.Core.Abstraction;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Core.Communication
{
    public abstract class JsonRequestBase<TEntity, TJsonEntity> : RequestBase<TEntity>
    {
        protected JsonRequestBase(ISignature signature, FilmWebHttpMethod filmWebHttpMethod) : base(signature, filmWebHttpMethod)
        {
        }

        public override async Task<TEntity> Parse(HttpResponseMessage responseMessage)
        {
            var jsonEntity = await GetJsonBody<TJsonEntity>(responseMessage).ConfigureAwait(false);
            return await Parse(jsonEntity).ConfigureAwait(false);
        }

        public abstract Task<TEntity> Parse(TJsonEntity entity);
    }
}