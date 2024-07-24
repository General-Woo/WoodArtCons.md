using System.ComponentModel.DataAnnotations.Schema;

namespace WoodArtCons.Shared.DataTransferObjects
{
    public class CategoryProductModelDto
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string NameRo { get; set; }
        public string NameRu { get; set; }
        public string NameEn { get; set; }
        public string ImageSrc { get; set; }
        public IEnumerable<string>? ListImagesSrc { get; set; }
        public float? Lenght { get; set; }
        public float? Height { get; set; }
        public float? Width { get; set; }
        public string? Link { get; set; }
        public string? DescriptionRo { get; set; }
        public string? DescriptionRu { get; set; }
        public string? DescriptionEn { get; set; }
        public string? MaterialRo { get; set; }
        public string? MaterialRu { get; set; }
        public string? MaterialEn { get; set; }
        public float Price { get; set; }
    }
}
