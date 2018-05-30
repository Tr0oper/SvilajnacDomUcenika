using AutoMapper;
using DomUcenikaSvilajnac.Common.Interfaces;
using DomUcenikaSvilajnac.Common.Models;
using DomUcenikaSvilajnac.Mapping;
using DomUcenikaSvilajnac.ModelResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace DomUcenikaSvilajnac.UnitTests
{
    [TestClass]
    public class MappingTest
    {

        [TestMethod]
        public void CreateMapMetode_ResursModelproveraTipa_ReturnsTrue()
        {
            Mapper.Initialize(m => m.AddProfile<MappingProfile>());
            Mapper.AssertConfigurationIsValid();
            Ucenik ucenik = new Ucenik()
            {
                Id = 1,
                Ime = "Pera",
                Prezime = "Peric",
                Pol = "Muski",
                JMBG = "1231231231233",
                DatumRodjenja = new DateTime(1998, 04, 30)
            };
            var result = Mapper.Map<Ucenik, UcenikResource>(ucenik);

            Assert.IsInstanceOfType(result, typeof(UcenikResource));
              AutoMapper.Mapper.Reset();

        }
        [TestMethod]
        public void CreateMapMetode_ModelResursproveraTipa_ReturnsTrue()
        {
            Mapper.Initialize(m => m.AddProfile<MappingProfile>());
            Mapper.AssertConfigurationIsValid();
            UcenikResource ucenik = new UcenikResource()
            {
                Id = 1,
                Ime = "Pera",
                Prezime = "Peric",
                Pol = "Muski",
                JMBG = "1231231231233",
                Dan = 5,
                Mesec = 11,
                Godina = 2001
            };
            var result = Mapper.Map<UcenikResource, Ucenik>(ucenik);

            Assert.IsInstanceOfType(result, typeof(Ucenik));
               AutoMapper.Mapper.Reset();

        }
        [TestMethod]
        public void CreateMapMetode_ModelResursproveraTipa_ReturnsFalseModel()
        {
            Mapper.Initialize(m => m.AddProfile<MappingProfile>());
            Mapper.AssertConfigurationIsValid();
            UcenikResource ucenik = new UcenikResource()
            {
                Id = 1,
                Ime = "Pera",
                Prezime = "Peric",
                Pol = "Muski",
                JMBG = "1231231231233",
                Dan = 5,
                Mesec = 11
            };

            try
            {
                var result = Mapper.Map<UcenikResource, Ucenik>(ucenik);

                Assert.Fail("OK");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is AutoMapperMappingException);
            }
            AutoMapper.Mapper.Reset();
        }






    }


}
    

