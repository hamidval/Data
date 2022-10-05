using Domain.Dtos;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.NHibernateMappings
{
    public class ResourceMap : ClassMapping<ResourceDto>
    {

        public ResourceMap() 
        {


            Table("Resources");

            Id(x => x.Id, m => 
            {
                m.Generator(Generators.Identity);
            });

            Property(x => x.ResourceTitle, m =>
            {
                m.Column("ResourceTitle");
            });

            Property(x => x.Price, m =>
            {
                m.Column("Price");
            });

            Property(x => x.AccessType, m =>
            {
                m.Column("Accesstype");
            });

            Property(x => x.Subject, m =>
            {
                m.Column("Subject");
            });

            Property(x => x.Level, m =>
            {
                m.Column("Level");
            });

            Property(x => x.ExamBoard, m =>
            {
                m.Column("ExamBoard");
            });

            Property(x => x.IsExamPractice, m =>
            {
                m.Column("IsExamPractice");
            });

            Property(x => x.IsExercise, m =>
            {
                m.Column("IsExercise");
            });

            Property(x => x.CreatedBy, m =>
            {
                m.Column("CreatedBy");
            });

            Property(x => x.ResourceStatus, m =>
            {
                m.Column("ResourceStatus");
            });

            Property(x => x.Description, m =>
            {
                m.Column("Description");
            });

            Property(x => x.ResourceType, m =>
            {
                m.Column("ResourceType");
            });








        }
    }
}
