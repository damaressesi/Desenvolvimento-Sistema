using System;

class Program
{
    static void Main()
    {
        //exercicio 1
        Pessoa p = new Pessoa("Damares", 40);
        p.exibirInformacoes();
        Console.WriteLine();

        //exercicio 2
        p.aniversario();
        p.exibirInformacoes();
        Console.WriteLine();

        //exercicio 3
        Alarme alarme = new Alarme();
        alarme.AlarmeAtivado += Alarme_Ativado;
        alarme.AtivarAlarme();
        Console.WriteLine();

        //exercicio 4
        ContaBancaria conta = new ContaBancaria();
        conta.SaldoAlterado += Saldo_Alterado;
        conta.AlterarSaldo(100);
        conta.exibirSaldo();    // Adicionar método para exibir saldo atual

        Console.WriteLine();
        conta.AlterarSaldo(-50);
        conta.exibirSaldo();
    }

    //-exercicio 3 Manipula o alarme ativado
    private static void Alarme_Ativado(object sender, EventArgs e)
    {
        Console.WriteLine("O alarme foi ativado!");
    }

    //exercicio  4 - Manipulador do evento para  alterar saldo
    private static void Saldo_Alterado(object sender, EventArgs e)
    {
        Console.WriteLine("O saldo foi alterado!");
    }
}
class Pessoa
{
    private string Nome;
    private int Idade;

    public Pessoa(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }
    public void exibirInformacoes()
    {
        Console.WriteLine($"Nome: {Nome} Idade: {Idade}");
    }
    //Exercicio2
    public void aniversario()
    {
        Idade++;
        Console.WriteLine(Nome + " fez aniversário!");
    }
}

//Eexercicio 3
class Alarme
{
    //Serve quando o alrme for ativado
    public event EventHandler AlarmeAtivado;

    //Serve para ativar e disparar o alarme
    public void AtivarAlarme()
    {
        OnAlarmeAtivado(EventArgs.Empty);
    }
    //Protegido para disparar o evento
    protected virtual void OnAlarmeAtivado(EventArgs e)
    {
        AlarmeAtivado?.Invoke(this, e);
    }
}

//Eexrcicio 4
class ContaBancaria
{
    private double Saldo { get; set; }

    /*
    public double Saldo //PROPRIEDADE AUTO-IMPLEMENTADA PARA O SALDO
    {
        get => saldo;
        private set
        {
            if(saldo != value)  //CONDICIONAL PARA DISPARAR O EVENTO SOMENTE SE O VALOR MUDAR
            {
                saldo = value;
                OnSaldoAlterado(EventArgs.Empty);
            }
        }
    }*/

    //Serve quando o evento for disparado
    public event EventHandler SaldoAlterado;

    //Método para alterar saldo
    public void AlterarSaldo(double valor)
    {
        Saldo += valor;
        OnSaldoAlterado(EventArgs.Empty);
    }
    protected virtual void OnSaldoAlterado(EventArgs e)
    {
        SaldoAlterado?.Invoke(this, e);
    }

    public void exibirSaldo()
    {
        Console.WriteLine($"Saldo atual: {Saldo:C}");
    }
}
