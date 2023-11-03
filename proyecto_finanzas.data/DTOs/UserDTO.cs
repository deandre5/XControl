namespace poryecto_finanzas.DTOs
{
    public class UserDTO
    {
        public string Nombre { get; set; }
        public int Id { get; set; }
        public string Token { get; set; }

        public UserDTO(string nombre, int id, string token = null)
        {
            Nombre = nombre;
            Id = id;
            Token = token;
        }

        public UserDTO() { }
    }
}
