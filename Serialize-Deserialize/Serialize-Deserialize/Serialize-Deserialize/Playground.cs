using FluentAssertions;
using static System.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SerializeDeserialize.Objects;

namespace Serialize_Deserialize
{
    [TestClass]
    public class Playground
    {
        private const string PRODUCTASJSON = "{\"Id\":101,\"Name\":\"Red Apple\",\"Price\":1.99}";
        private readonly Product product;

        public Playground()
        {
            product = new Product
            {
                Id = 101,
                Name = "Red Apple",
                Price = 1.99m
            };
        }

        [TestMethod]
        public void Serialize()
        {
            //Serialize the product object to JSON string
            var productJson = JsonConvert.SerializeObject(product);

            productJson.Should().BeEquivalentTo(PRODUCTASJSON);
        }

        [TestMethod]
        public void Deserialize()
        {
            var convertToProduct = JsonConvert.DeserializeObject<Product>(PRODUCTASJSON);

            convertToProduct.ShouldBeEquivalentTo(product);
        }
    }
}
