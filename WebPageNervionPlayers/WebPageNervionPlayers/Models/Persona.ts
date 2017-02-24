export class Persona {


    private id: number;
    private nombre: string;
    private apellidos: string;
    private contraseña: string;

    private alias: string;
    private correo: string;
    private fecha_Creacion: Date;
    private curso: number;
    private letra: string;
    private observaciones: string;
    private confirmado: boolean;
    private foto;

    constructor(id, nombre, alias, correo, fecha_Creacion, curso, letra, observaciones, confirmado, contraseña,apellidos, foto) {
        this.id = id;
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.contraseña = contraseña;
        this.alias = alias;
        this.correo = correo;
        this.fecha_Creacion = fecha_Creacion;
        this.curso = curso;
        this.letra = letra;
        this.observaciones = observaciones;
        this.confirmado = confirmado;
        this.foto = foto;
    }

    public getID(): number {
        return this.id;
    }

    public getNombre(): string {
        return this.nombre;
    }

    public getContraseña(): string {
        return this.contraseña;
    }

    public getAlias(): string {
        return this.alias;
    }

    public getConfirmado(): boolean{
        return this.confirmado;
    }
}