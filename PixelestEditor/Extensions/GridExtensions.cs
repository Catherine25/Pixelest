using System.Windows.Controls;

namespace PixelestEditor.Extensions
{
    public static class GridExtension
    {
        public static void AddColumns(this Grid grid, int count)
        {
            for (int i = 0; i < count; i++)
                grid.ColumnDefinitions.Add(new ColumnDefinition());
        }

        public static void AddRows(this Grid grid, int count)
        {
            for (int i = 0; i < count; i++)
                grid.RowDefinitions.Add(new RowDefinition());
        }

        public static void AddColumnsAndRows(this Grid grid, int columns, int rows)
        {
            grid.AddColumns(columns);
            grid.AddRows(rows);
        }
    }
}