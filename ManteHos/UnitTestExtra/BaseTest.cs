using ManteHos.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestExtra
{
    [TestClass]
    public class BaseTest
    {
        protected EntityFrameworkDAL dal;
        protected DbContextISW dbContext;

        [TestInitialize]
        public void IniTests()
        {
            dbContext = new ManteHosDbContext();
            dal = new EntityFrameworkDAL(dbContext);

            dal.RemoveAllData();


        }
        [TestCleanup]
        public void CleanTests()
        {
            dal.RemoveAllData();
        }
    }

 }
