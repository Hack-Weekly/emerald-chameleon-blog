using ApiServer.AutoMapperProfiles;
using ApiServer.Shared;
using AutoMapper;

namespace ApiServer.AutoMapperProfiles
{
    public static class IEntityExtensions
    {
        private static readonly IMapper AutoMapper =
            new Mapper(new MapperConfiguration(ex =>
            {
                ex.AddProfile(new EntityToDTOProfile());
            }));

        public static TDTO MapToDTO<TDTO>(this IEntity entity)
           where TDTO : class, IDTO
        {
            return AutoMapper.Map<TDTO>(entity);
        }

        public static TDTO MapToDTO<TDTO>(this IEnumerable<IEntity> entity)
            where TDTO : IEnumerable<IDTO>
        {
            return AutoMapper.Map<TDTO>(entity);
        }
    }
}
