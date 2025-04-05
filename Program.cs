using System;
using System.Collections.Generic;
using System.Text;

namespace IronSoftwareCodingChallenge
{
    /// <summary>
    /// Clase que implementa la lógica para decodificar una cadena de entrada
    /// basada en el antiguo teclado telefónico.
    /// </summary>
    public static class OldPhonePadDecoder
    {
        // Mapeo de dígitos a sus letras correspondientes, de acuerdo a lo especificado.
        // Nota: Los dígitos 1 y 0 se asignan según la descripción (1: "&’(", 0: espacio o sin asignación).
        private static readonly Dictionary<char, string> PhoneMapping = new Dictionary<char, string>
        {
            { '1', "&’(" },
            { '2', "abc" },
            { '3', "def" },
            { '4', "ghi" },
            { '5', "jkl" },
            { '6', "mno" },
            { '7', "pqrs" },
            { '8', "tuv" },
            { '9', "wxyz" },
            // Se puede asignar el 0 a un espacio u otro carácter si es necesario; en este ejemplo lo dejamos sin asignación.
            { '0', " " }
        };

        /// <summary>
        /// Decodifica la cadena de entrada según el antiguo teclado telefónico.
        /// La cadena de entrada debe terminar en el carácter de envío (“#”).
        /// Se interpreta la tecla de retroceso (“*”) para eliminar el último carácter.
        /// Los espacios en la entrada actúan como pausa para separar secuencias de pulsaciones.
        /// </summary>
        /// <param name="input">La cadena de entrada a decodificar.</param>
        /// <returns>El mensaje decodificado.</returns>
        public static string OldPhonePad(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("La entrada no puede ser nula o vacía.");

            StringBuilder output = new StringBuilder();
            StringBuilder currentSequence = new StringBuilder();

            // Procesamos cada carácter hasta el caracter de envío '#'
            foreach (char c in input)
            {
                if (c == '#')
                {
                    // Fin de entrada, decodificamos secuencia pendiente si la hubiera y salimos.
                    ProcessSequence(currentSequence, output);
                    break;
                }
                else if (c == ' ')
                {
                    // El espacio indica una pausa: se procesa la secuencia acumulada y se reinicia.
                    ProcessSequence(currentSequence, output);
                }
                else if (c == '*')
                {
                    // La tecla de retroceso: se procesa la secuencia pendiente, si la hubiera,
                    // y se elimina el último carácter del resultado.
                    ProcessSequence(currentSequence, output);
                    if (output.Length > 0)
                        output.Remove(output.Length - 1, 1);
                }
                else if (char.IsDigit(c))
                {
                    // Si la secuencia actual está vacía o el dígito es el mismo que el anterior, se acumula.
                    if (currentSequence.Length == 0 || currentSequence[currentSequence.Length - 1] == c)
                    {
                        currentSequence.Append(c);
                    }
                    else
                    {
                        // Si se cambia de botón, se procesa la secuencia anterior.
                        ProcessSequence(currentSequence, output);
                        currentSequence.Append(c);
                    }
                }
                // Se ignoran otros caracteres.
            }

            return output.ToString();
        }

        /// <summary>
        /// Procesa la secuencia acumulada de dígitos y agrega el carácter decodificado al StringBuilder de salida.
        /// Luego, reinicia la secuencia.
        /// </summary>
        /// <param name="sequence">Secuencia acumulada de dígitos.</param>
        /// <param name="output">Salida donde se agregará el carácter decodificado.</param>
        private static void ProcessSequence(StringBuilder sequence, StringBuilder output)
        {
            if (sequence.Length == 0)
                return;

            char key = sequence[0];
            int pressCount = sequence.Length;

            if (PhoneMapping.ContainsKey(key))
            {
                string letters = PhoneMapping[key];
                // Se utiliza la pulsación count para obtener el índice (se usa módulo en caso de ciclos)
                int index = (pressCount - 1) % letters.Length;
                // Se agrega el carácter convertido en mayúscula para la salida final
                output.Append(char.ToUpper(letters[index]));
            }
            // Reinicia la secuencia.
            sequence.Clear();
        }
    }

    /// <summary>
    /// Clase que contiene casos de prueba para verificar el funcionamiento del decodificador.
    /// </summary>
    public static class OldPhonePadTests
    {
        public static void RunTests()
        {
            // Definición de casos de prueba (entrada, salida esperada)
            var testCases = new Dictionary<string, string>
            {
                { "33#", "E" },
                { "227*#", "B" },
                { "4433555 555666#", "HELLO" },
                // En el siguiente caso se muestra el manejo de retroceso y pausas.
                { "8 88777444666*664#", "TURING" }
            };

            foreach (var test in testCases)
            {
                try
                {
                    string result = OldPhonePadDecoder.OldPhonePad(test.Key);
                    string status = result == test.Value ? "OK" : $"ERROR (obtuvo \"{result}\")";
                    Console.WriteLine($"Entrada: \"{test.Key}\", Salida esperada: \"{test.Value}\", Resultado: {status}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Entrada: \"{test.Key}\" provocó excepción: {ex.Message}");
                }
            }
        }
    }

    /// <summary>
    /// Clase principal para ejecutar la aplicación y los casos de prueba.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ejecutando casos de prueba para OldPhonePadDecoder...\n");
            OldPhonePadTests.RunTests();
            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
