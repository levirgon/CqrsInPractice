﻿using FluentNHibernate;
using FluentNHibernate.Mapping;

namespace Logic.Students
{
    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Id(x => x.Id);

            Map(x => x.Name);
            Map(x => x.Email);

            HasMany<Enrollment>(Reveal.Member<Student>("_enrollments")).Access.Field().Inverse().Cascade.AllDeleteOrphan();
            HasMany(x => x.Disenrollments).Access.CamelCaseField(Prefix.Underscore).Inverse().Cascade.AllDeleteOrphan();
        }
    }
}
