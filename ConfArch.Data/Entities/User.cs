namespace ConfArch.Data.Entities;

public class User : IEntity
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string FavoriteColor { get; set; }
    public string Role { get; set; }
    public string GoogleId { get; set; }
}
