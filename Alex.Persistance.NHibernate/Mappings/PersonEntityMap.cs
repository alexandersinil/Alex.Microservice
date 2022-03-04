using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Alex.Entities;

namespace Alex.Persistance.NHibernate.Mappings
{
    public class PersonEntityMap : ClassMap<PersonEntity>
    {
        public PersonEntityMap()
        {
            Table("PERSONS");

            Id(e => e.Id)
                .Column("ID")
                .GeneratedBy.Sequence("seq_person")
                ;

            Map(e => e.FisrtName)
                .Column("FIRSTNAME")
                .Not.Nullable();

            Map(e => e.LastName)
                .Column("LASTNAME")
                .Not.Nullable();

            Map(e => e.Age)
                .Column("AGE")
                .Not.Nullable();
        }
    }
}
