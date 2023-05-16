using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP
{

    //interface ICelular
    //{
    //    void send_email();
    //    string send_password();
    //}


    //abstract class Celular
    //{   
    //    List<string> list;
    //    public int volume;
    //    public float battery;
    //    public bool flashlight = true;
    //    public bool Bluetooth = false;

    //    public Celular(int volume, float battery, bool flashlight, bool bluetooth)
    //    {
    //        this.volume = volume;
    //        this.battery = battery;
    //        this.flashlight = flashlight;
    //        Bluetooth = bluetooth;
    //    }

    //    public void change_flash_status()
    //    {
    //        if (flashlight) { flashlight = true; Console.WriteLine("Ligado"); }
    //        else { flashlight = false; Console.WriteLine("Desligado"); }
    //    }

    //    public virtual void change_volume(bool choice)
    //    {
    //        if (choice) { while (volume < 30) { volume++; Console.WriteLine(true); break; } }
    //        else { while (volume > 0) { volume++; Console.WriteLine(false); break; } }
    //    }

    //    public abstract string games_apps();

    //    public abstract bool app_notifications();


    //}

    //class Ipad : Celular, ICelular
    //{
    //    List<string> login_itunes = new List<string>();
    //    string user_name;
    //    int cel_id;

    //    public Ipad(string user_nome, int cel_id, int volume, float battery, bool flashlight, bool bluetooth) : base(volume, battery, flashlight, bluetooth)
    //    {
    //        this.user_name = user_nome;
    //        this.cel_id = cel_id;
    //    }
    //    public void change_volume()
    //    {
    //        base.change_volume(false);
    //    }

    //    void send_email()
    //    {
    //         Console.WriteLine("o email foi enviad");
    //    }
    //    string send_password()
    //    {
    //        return "passWord";
    //    }

    //}


    //class Tablet : Celular
    //{
    //    public float display_size;

    //    public Tablet(float display_size, int volume, float battery, bool flashlight, bool bluetooth) : base(volume, battery, flashlight, bluetooth)
    //    {
    //        this.display_size = display_size;
    //    }

    //    public override void change_volume(bool choice)
    //    {
    //        base.change_volume(choice);
    //        Console.WriteLine(choice + " teste do override");
    //    }

    //    void send_email()
    //    {
    //        Console.WriteLine("o emeail foi enviado de um tablet");
    //    }
    //    private string send_password()
    //    {
    //        return "a senha do tablet e";
    //    }
    //}
}
