namespace MYL.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public Questionary Questionary { get; set; }
        public User User { get; set; }
    }
}
