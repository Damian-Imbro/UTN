namespace TP_integrador.Operadores
{
    [Serializable]
    public enum EstadoOperador
    {
        GuardadoEnCuartel,
        EnMovimiento,
        Encendido,
        Dañado,
        CargandoBateria,
        TranfiriendoCarga,
        CargandoBatería,
        EnTallerReparacion,
        EsperandoOrdenes,
        Standby,
        Removido
    }
}
