using Domain.Dtos;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.NHibernateMappings
{
    public class ResourceFileMap : ClassMapping<ResourceFileDto>
    {

        public ResourceFileMap() 
        {
            Table("ResourceFiles");

            Id(x => x.Id, m => 
            {
                m.Generator(Generators.Identity);
            });

            Property(x => x.ResourceId, m =>
            {
                m.Column("ResourceId");
            });

            Property(x => x.Url, m =>
            {
                m.Column("Url");
            });

            Property(x => x.UniqueFileName, m =>
            {
                m.Column("UniqueFileName");
            });

            Property(x => x.FileType, m =>
            {
                m.Column("FileType");
            });

        }
    }
}
