using Microsoft.AspNetCore.Hosting.Server;

namespace cmodulechatbot.Models
{
    public class ServiceModel
    {

        public string name { get; set; }
        public int price { get; set; }
        public string? description { get; set; }
        public string image { get; set; }

        public ServiceModel(string _name, int _price, string _description, string _image)
        {
            name = _name;
            price = _price;
            description = _description;
            image = _image;
        }

    }
}
