namespace Homework
{
    public class Assignment
    {
        // Atributos privados: solo accesibles dentro de esta clase
        private string _studentName;
        private string _topic;

        // Constructor que inicializa los valores comunes
        public Assignment(string studentName, string topic)
        {
            _studentName = studentName;
            _topic = topic;
        }

        // Método para obtener el resumen (Nombre - Tema)
        public string GetSummary()
        {
            return $"{_studentName} - {_topic}";
        }

        // Getter público para que las clases hijas accedan al nombre, 
        // ya que el atributo es privado
        public string GetStudentName()
        {
            return _studentName;
        }
    }
}