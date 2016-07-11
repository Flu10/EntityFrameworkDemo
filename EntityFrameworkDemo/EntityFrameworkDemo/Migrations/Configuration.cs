namespace EntityFrameworkDemo.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using HrContext;
    using Model.Nomenclatures;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityFrameworkDemo.HrContext.HrContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EntityFrameworkDemo.HrContext.HrContext context)
        {
            PopulateGenderEnum(context);
            PopulateLevelEnum(context);
        }

        private void PopulateLevelEnum(HrContext context)
        {
            var levelList = new List<Level>
            {
                new Level { Id =1, Name ="Junior" },
                new Level { Id =2, Name ="Middle" },
                new Level { Id =3, Name ="Senior" }
            };

            foreach (var level in levelList)
            {
                context.Levels.AddOrUpdate(p => p.Name, level);
            }
        }

        private void PopulateGenderEnum(HrContext context)
        {
            var genderList = new List<Gender>
            {
                new Gender { Id =1, Name ="Masculin" },
                new Gender { Id =2, Name ="Feminin" }
            };

            foreach (var gender in genderList)
            {
                context.Genders.AddOrUpdate(p => p.Name, gender);
            }
        }
    }
}
