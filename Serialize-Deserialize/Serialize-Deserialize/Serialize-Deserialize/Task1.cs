using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SerializeDeserialize.Objects;

namespace SerializeDeserialize
{
    
    public class Task1
    {
        [TestClass]
        public class Task
        {
            [TestMethod]
            public void RocketsToJson()
            {
                IEnumerable<Rocket> rockets = new[]
                {
                    new Rocket {Id = 0, Builder = "NASA", Target = "Moon", Speed = 7.8},
                    new Rocket {Id = 1, Builder = "NASA", Target = "Mars", Speed = 10.9},
                    new Rocket {Id = 2, Builder = "NASA", Target = "Kepler-452b", Speed = 42.1},
                    new Rocket {Id = 3, Builder = "NASA", Target = "N/A", Speed = 0}
                };

                var json = JsonConvert.SerializeObject(rockets);

                const string EXPECTED =
                    "[{\"Id\":0,\"Builder\":\"NASA\",\"Target\":\"Moon\",\"Speed\":7.8},{\"Id\":1,\"Builder\":\"NASA\",\"Target\":\"Mars\",\"Speed\":10.9},{\"Id\":2,\"Builder\":\"NASA\",\"Target\":\"Kepler-452b\",\"Speed\":42.1},{\"Id\":3,\"Builder\":\"NASA\",\"Target\":\"N/A\",\"Speed\":0.0}]";
                json.Should().BeEquivalentTo(EXPECTED);
            }

            [TestMethod]
            public void JsonToRockets()
            {
                const string JSON =
                    "[{\"Id\":0,\"Builder\":\"NASA\",\"Target\":\"Moon\",\"Speed\":7.8},{\"Id\":1,\"Builder\":\"NASA\",\"Target\":\"Mars\",\"Speed\":10.9},{\"Id\":2,\"Builder\":\"NASA\",\"Target\":\"Kepler-452b\",\"Speed\":42.1},{\"Id\":3,\"Builder\":\"NASA\",\"Target\":\"N/A\",\"Speed\":0.0}]";

                var rockets = JsonConvert.DeserializeObject<IEnumerable<Rocket>>(JSON).ToArray();

                rockets.Should().NotBeNullOrEmpty();
                rockets.Should().BeAssignableTo<IEnumerable<Rocket>>();
                rockets.Should().BeOfType<Rocket[]>();

                rockets.Length.ShouldBeEquivalentTo(4);

                rockets[0].Target.Should().BeEquivalentTo("Moon");
                rockets[1].Target.Should().BeEquivalentTo("Mars");
                rockets[2].Target.Should().BeEquivalentTo("Kepler-452b");
                rockets[3].Target.Should().BeEquivalentTo("N/A");
            }
        }

        [TestClass]
        public class Bonus
        {
            [TestMethod]
            public void LooseCoupling()
            {
                const string ROCKETSJSON =
                    "[{\"Id\":0,\"Builder\":\"NASA\",\"Target\":\"Moon\",\"Speed\":7.8},{\"Id\":1,\"Builder\":\"NASA\",\"Target\":\"Mars\",\"Speed\":10.9},{\"Id\":2,\"Builder\":\"NASA\",\"Target\":\"Kepler-452b\",\"Speed\":42.1},{\"Id\":3,\"Builder\":\"NASA\",\"Target\":\"N/A\",\"Speed\":0.0}]";

                var ufos = JsonConvert.DeserializeObject<IEnumerable<Ufo>>(ROCKETSJSON).ToArray();

                ufos.Length.ShouldBeEquivalentTo(4);

                ufos[0].Target.Should().BeEquivalentTo("Moon");
                ufos[1].Target.Should().BeEquivalentTo("Mars");
                ufos[2].Target.Should().BeEquivalentTo("Kepler-452b");
                ufos[3].Target.Should().BeEquivalentTo("N/A");
            }
        }
    }
}
