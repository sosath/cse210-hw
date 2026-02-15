using System;

// CREATIVIDAD Y EXCESO DE REQUISITOS:
// 1. Sistema de Niveles: El usuario sube de nivel cada 1000 puntos.
// 2. Títulos Dinámicos: El usuario recibe un título según su nivel (ej. "Nivel 2: Guerrero").
// 3. Animaciones de Consola: Se añadieron efectos visuales sencillos al ganar puntos.

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}