namespace WoodArtCons.Server.WoodArtCons.Persistence.Entities
{
    public class CategoryModel
    {
        public string Id{ get; set; }
        public string NameRo { get; set; }
        public string NameRu { get; set; }
        public string NameEn { get; set; }
        public string ImageSrc { get; set; }
        public string Link { get; set; }
        public bool IsForGalery { get; set; }
    }
}
