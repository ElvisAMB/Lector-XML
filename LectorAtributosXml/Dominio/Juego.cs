namespace Dominio
{
    public class Juego
    {
        private int idJuego;
        private string nombreJuego;
        private string generoJuego;
        private string plataformaJuego;
        private string companiaCreadora;

        /// <summary>
        /// Metodo constuctor sin parametros.
        /// </summary>
        public Juego()
        {
        }//Fin de metodo constructor sin parametros.

        /// <summary>
        /// Metodo constructor con parametros.
        /// </summary>
        /// <param name="idJuego">identificador del juego</param>
        /// <param name="nombreJuego">nombre del juego</param>
        /// <param name="generoJuego">genero del juego</param>
        /// <param name="plataformaJuego">plataforma del juego</param>
        /// <param name="companiaJuego">nombre de la compania del juego</param>
        public Juego(int idJuego, string nombreJuego, string generoJuego, string plataformaJuego, string companiaJuego)
        {
            this.IdJuego = idJuego;
            this.NombreJuego = nombreJuego;
        }//Fin de metodo constructor.

        public int IdJuego
        {
            get
            {
                return idJuego;
            }//Fin de get.
            set
            {
                idJuego = value;
            }//Fin de set.
        }//Fin de propiedad IdJuego.

        public string NombreJuego
        {
            get
            {
                return nombreJuego;
            }//Fin de get.
            set
            {
                nombreJuego = value;
            }//Fin de set.
        }//Fin de propiedad NombreJuego.

        public string GeneroJuego
        {
            get
            {
                return generoJuego;
            }//Fin de get.
            set
            {
                generoJuego = value;
            }//Fin de set.
        }//Fin de propiedad GeneroJuego.

        public string PlataformaJuego
        {
            get
            {
                return plataformaJuego;
            }//Fin de get
            set
            {
                this.plataformaJuego = value.Trim();
            }//Fin de set.
        }//Fin de propiedad PlataformaJuego.

        public string CompaniaCreadora
        {
            get
            {
                return companiaCreadora;
            }//Fin de get
            set
            {
                this.companiaCreadora = value.Trim();
            }//Fin de set.
        }//Fin de propiedad CompaniaCreadora.

        public override string ToString()
        {
            return "-----------------Juego------------------\n ID= " + IdJuego + "\n Nombre=" + NombreJuego + "\n Genero= " + GeneroJuego + "\n Compañia= " + CompaniaCreadora + "\n----------------------------------------";
        }
    }
}
