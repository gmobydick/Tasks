using FluentNHibernate.Mapping;
using TaskDO.Entities;

namespace TaskDO.Mapping
{
    public abstract class EntityMap<T> : ClassMap<T> where T : Entity
    {
        public EntityMap()
        {
            //Id(x => x.Id).GeneratedBy.GuidComb().UnsavedValue("00000000-0000-0000-0000-000000000000");
            Id(x => x.Id);
            Version(x => x.Version);
            Map(x => x.Name).Length(80);
            Map(x => x.Description).Length(100);
            //Map(x => x.Name).Unique("UnKeyiqueKey_TCountry_CName").Length(30);
            Map(x => x.CreatedBy).Nullable().Length(50);
            Map(x => x.CreatedAt).Nullable();
            //.Generated.Insert().CustomSqlType("datetime")
            //Map(x => x.UpdatedBy).Nullable().Length(50);
            //Map(x => x.UpdatedDate).Nullable().Generated.Insert().CustomSqlType("timestamp");
        }
    }
}