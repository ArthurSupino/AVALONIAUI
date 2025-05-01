using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace AvaloniaProject;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ConvertButton_Click(object? sender, RoutedEventArgs e)
    {
        // Obter o tipo de conversão selecionado
        var selectedConversion = (ConversionList.SelectedItem as ListBoxItem)?.Content?.ToString();
        if (string.IsNullOrEmpty(selectedConversion))
        {
            OutputValue.Text = "Selecione um tipo de conversão.";
            return;
        }

        // Validar o valor de entrada
        if (!double.TryParse(InputValue.Text, out double inputValue))
        {
            OutputValue.Text = "Insira um valor numérico válido.";
            return;
        }

        // Aplicar a fórmula de conversão
        double result = selectedConversion switch
        {
            "Celsius para Fahrenheit" => (inputValue * 1.8) + 32,
            "Fahrenheit para Celsius" => (inputValue - 32) / 1.8,
            "Celsius para Kelvin" => inputValue + 273.15,
            "Kelvin para Celsius" => inputValue - 273.15,
            "Metros para Pés" => inputValue * 3.28084,
            "Pés para Metros" => inputValue * 0.3048,
            "Quilômetros para Milhas" => inputValue * 0.621371,
            "Milhas para Quilômetros" => inputValue * 1.60934,
            "Quilogramas para Libras" => inputValue * 2.20462,
            "Libras para Quilogramas" => inputValue * 0.453592,
            "Gramas para Onças" => inputValue * 0.035274,
            "Onças para Gramas" => inputValue * 28.3495,
            "Litros para Galões" => inputValue * 0.264172,
            "Galões para Litros" => inputValue * 3.78541,
            "Mililitros para Onças Fluidas" => inputValue * 0.033814,
            "Onças Fluidas para Mililitros" => inputValue * 29.5735,
            _ => double.NaN
        };

        // Exibir o resultado
        OutputValue.Text = double.IsNaN(result) ? "Erro na conversão." : result.ToString("F2");
    }
}

