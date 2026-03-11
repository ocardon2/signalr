namespace Models
{
    /// <summary>
    /// Clase que representa los usuarios
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Id del usuario
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string Nombre { get; set; } = string.Empty;
        /// <summary>
        /// Estado del usuario, true activo, false inactivo
        /// </summary>
        public bool Activo { get; set; }
    }
}
