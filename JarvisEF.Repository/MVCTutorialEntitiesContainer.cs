using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JarvisEF.Repository
{
    public class MVCTutorialEntitiesContainer : DbContext
    {
        public MVCTutorialEntitiesContainer()
        {

        }

        public MVCTutorialEntitiesContainer(DbContextOptions<MVCTutorialEntitiesContainer> options)
            : base(options)
        {

        }
    }
}
