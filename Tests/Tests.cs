using App.Entidades;

namespace Tests
{
    public class Tests
    {
        private Biblioteca _biblioteca;
        private Libro _libro1;
        private Libro _libro2;

        [SetUp]
        public void Setup()
        {
            _biblioteca = new Biblioteca();
            _libro1 = new Libro("1984", "George Orwell");
            _libro2 = new Libro("El Principito", "Antoine de Saint-Exupéry");
            _biblioteca.AgregarLibro(_libro1);
            _biblioteca.AgregarLibro(_libro2);
        }

        [Test]
        public void PrestarLibro_LibroDisponible_PrestaLibroCorrectamente()
        {
            // Act
            _biblioteca.PrestarLibro("1984");

            // Assert
            Assert.IsTrue(_libro1.EstaPrestado);
        }

        [Test]
        public void PrestarLibro_LibroNoDisponible_LanzaExcepcion()
        {
            // Act
            _biblioteca.PrestarLibro("1984");
            Assert.Throws<InvalidOperationException>(() => _biblioteca.PrestarLibro("1984"));
            // Assert
        }

        [Test]
        public void DevolverLibro_LibroPrestado_DevolveLibroCorrectamente()
        {
            // Act
            _biblioteca.PrestarLibro("1984");
            _biblioteca.DevolverLibro("1984");

            // Assert
            Assert.IsFalse(_libro1.EstaPrestado);
        }

        [Test]
        public void DevolverLibro_LibroNoPrestado_LanzaExcepcion()
        {
            // Act
            Assert.Throws<InvalidOperationException>(() => _biblioteca.DevolverLibro("1984"));

            // Assert
        }

        [Test]
        public void ObtenerLibros_RetornaListaDeLibros()
        {
            // Act
            var libros = _biblioteca.ObtenerLibros();

            // Assert
            Assert.IsNotNull(libros);
            Assert.IsInstanceOf<List<Libro>>(libros);
            Assert.AreEqual(2, libros.Count);
            Assert.Contains(_libro1, libros);
            Assert.Contains(_libro2, libros);
        }
    }
}