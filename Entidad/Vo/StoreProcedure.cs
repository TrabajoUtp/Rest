using System;
// ReSharper disable InconsistentNaming

namespace Entidad.Vo
{
    public class StoreProcedure
    {
        //Seguridad.Rol
        public const String Seguridad_usp_Rol_Obtener = "Seguridad.usp_Rol_Obtener";
        public const String Seguridad_usp_Rol_Combo = "Seguridad.usp_Rol_Combo";
        public const String Seguridad_usp_Rol_ObtenerPorId = "Seguridad.usp_Rol_ObtenerPorId";
        public const String Seguridad_usp_Rol_Registrar = "Seguridad.usp_Rol_Registrar";
        public const String Seguridad_usp_Rol_Modificar = "Seguridad.usp_Rol_Modificar";
        public const String Seguridad_usp_Rol_Eliminar = "Seguridad.usp_Rol_Eliminar";

        //Seguridad.Usuario
        public const String Seguridad_usp_Usuario_Obtener = "Seguridad.usp_Usuario_Obtener";
        public const String Seguridad_usp_Usuario_Combo = "Seguridad.usp_Usuario_Combo";
        public const String Seguridad_usp_Usuario_ObtenerPorId = "Seguridad.usp_Usuario_ObtenerPorId";
        public const String Seguridad_usp_Usuario_Registrar = "Seguridad.usp_Usuario_Registrar";
        public const String Seguridad_usp_Usuario_Modificar = "Seguridad.usp_Usuario_Modificar";
        public const String Seguridad_usp_Usuario_Eliminar = "Seguridad.usp_Usuario_Eliminar";
        public const String Seguridad_usp_Usuario_Login = "Seguridad.usp_Usuario_Login";

        //Seguridad.Acceso
        public const String Seguridad_usp_Acceso_Obtener = "Seguridad.usp_Acceso_Obtener";
        public const String Seguridad_usp_Acceso_Combo = "Seguridad.usp_Acceso_Combo";
        public const String Seguridad_usp_Acceso_ObtenerPorId = "Seguridad.usp_Acceso_ObtenerPorId";
        public const String Seguridad_usp_Acceso_Registrar = "Seguridad.usp_Acceso_Registrar";
        public const String Seguridad_usp_Acceso_Modificar = "Seguridad.usp_Acceso_Modificar";
        public const String Seguridad_usp_Acceso_Eliminar = "Seguridad.usp_Acceso_Eliminar";

        //Seguridad.AccesoRol
        public const String Seguridad_usp_AccesoRol_ObtenerPorIdUsuario = "Seguridad.usp_AccesoRol_ObtenerPorIdUsuario";

        //Maestro.Cliente
        public const String Maestro_usp_Cliente_Obtener = "Maestro.usp_Cliente_Obtener";
        public const String Maestro_usp_Cliente_Combo = "Maestro.usp_Cliente_Combo";
        public const String Maestro_usp_Cliente_ObtenerPorId = "Maestro.usp_Cliente_ObtenerPorId";
        public const String Maestro_usp_Cliente_Registrar = "Maestro.usp_Cliente_Registrar";
        public const String Maestro_usp_Cliente_Modificar = "Maestro.usp_Cliente_Modificar";
        public const String Maestro_usp_Cliente_Eliminar = "Maestro.usp_Cliente_Eliminar";

        //Maestro.TipoIncidencia
        public const String Maestro_usp_TipoCorreo_Obtener = "Maestro.usp_TipoCorreo_Obtener";
        public const String Maestro_usp_TipoCorreo_Combo = "Maestro.usp_TipoCorreo_Combo";
        public const String Maestro_usp_TipoCorreo_ObtenerPorId = "Maestro.usp_TipoCorreo_ObtenerPorId";
        public const String Maestro_usp_TipoCorreo_Registrar = "Maestro.usp_TipoCorreo_Registrar";
        public const String Maestro_usp_TipoCorreo_Modificar = "Maestro.usp_TipoCorreo_Modificar";
        public const String Maestro_usp_TipoCorreo_Eliminar = "Maestro.usp_TipoCorreo_Eliminar";

        //Maestro.TipoIncidencia
        public const String Maestro_usp_TipoIncidencia_Obtener = "Maestro.usp_TipoIncidencia_Obtener";
        public const String Maestro_usp_TipoIncidencia_Combo = "Maestro.usp_TipoIncidencia_Combo";
        public const String Maestro_usp_TipoIncidencia_ObtenerPorId = "Maestro.usp_TipoIncidencia_ObtenerPorId";
        public const String Maestro_usp_TipoIncidencia_Registrar = "Maestro.usp_TipoIncidencia_Registrar";
        public const String Maestro_usp_TipoIncidencia_Modificar = "Maestro.usp_TipoIncidencia_Modificar";
        public const String Maestro_usp_TipoIncidencia_Eliminar = "Maestro.usp_TipoIncidencia_Eliminar";

        //Maestro.Motivo
        public const String Maestro_usp_Motivo_Obtener = "Maestro.usp_Motivo_Obtener";
        public const String Maestro_usp_Motivo_Combo = "Maestro.usp_Motivo_Combo";
        public const String Maestro_usp_Motivo_ObtenerPorId = "Maestro.usp_Motivo_ObtenerPorId";
        public const String Maestro_usp_Motivo_Registrar = "Maestro.usp_Motivo_Registrar";
        public const String Maestro_usp_Motivo_Modificar = "Maestro.usp_Motivo_Modificar";
        public const String Maestro_usp_Motivo_Eliminar = "Maestro.usp_Motivo_Eliminar";

        //Maestro.Area
        public const String Maestro_usp_Area_Obtener = "Maestro.usp_Area_Obtener";
        public const String Maestro_usp_Area_Combo = "Maestro.usp_Area_Combo";
        public const String Maestro_usp_Area_ObtenerPorId = "Maestro.usp_Area_ObtenerPorId";
        public const String Maestro_usp_Area_Registrar = "Maestro.usp_Area_Registrar";
        public const String Maestro_usp_Area_Modificar = "Maestro.usp_Area_Modificar";
        public const String Maestro_usp_Area_Eliminar = "Maestro.usp_Area_Eliminar";

        //Maestro.Prioridad
        public const String Maestro_usp_Prioridad_Obtener = "Maestro.usp_Prioridad_Obtener";
        public const String Maestro_usp_Prioridad_Combo = "Maestro.usp_Prioridad_Combo";
        public const String Maestro_usp_Prioridad_ObtenerPorId = "Maestro.usp_Prioridad_ObtenerPorId";
        public const String Maestro_usp_Prioridad_Registrar = "Maestro.usp_Prioridad_Registrar";
        public const String Maestro_usp_Prioridad_Modificar = "Maestro.usp_Prioridad_Modificar";
        public const String Maestro_usp_Prioridad_Eliminar = "Maestro.usp_Prioridad_Eliminar";

        //Maestro.CategoriaFaq
        public const String Maestro_usp_CategoriaFaq_Obtener = "Maestro.usp_CategoriaFaq_Obtener";
        public const String Maestro_usp_CategoriaFaq_Combo = "Maestro.usp_CategoriaFaq_Combo";
        public const String Maestro_usp_CategoriaFaq_ObtenerPorId = "Maestro.usp_CategoriaFaq_ObtenerPorId";
        public const String Maestro_usp_CategoriaFaq_Registrar = "Maestro.usp_CategoriaFaq_Registrar";
        public const String Maestro_usp_CategoriaFaq_Modificar = "Maestro.usp_CategoriaFaq_Modificar";
        public const String Maestro_usp_CategoriaFaq_Eliminar = "Maestro.usp_CategoriaFaq_Eliminar";

        //Maestro.TipoEstado
        public const String Maestro_usp_TipoEstado_Obtener = "Maestro.usp_TipoEstado_Obtener";
        public const String Maestro_usp_TipoEstado_Combo = "Maestro.usp_TipoEstado_Combo";
        public const String Maestro_usp_TipoEstado_ObtenerPorId = "Maestro.usp_TipoEstado_ObtenerPorId";
        public const String Maestro_usp_TipoEstado_Registrar = "Maestro.usp_TipoEstado_Registrar";
        public const String Maestro_usp_TipoEstado_Modificar = "Maestro.usp_TipoEstado_Modificar";
        public const String Maestro_usp_TipoEstado_Eliminar = "Maestro.usp_TipoEstado_Eliminar";

        //Maestro.Estado
        public const String Maestro_usp_Estado_Obtener = "Maestro.usp_Estado_Obtener";
        public const String Maestro_usp_Estado_Combo = "Maestro.usp_Estado_Combo";
        public const String Maestro_usp_Estado_ObtenerPorId = "Maestro.usp_Estado_ObtenerPorId";
        public const String Maestro_usp_Estado_Registrar = "Maestro.usp_Estado_Registrar";
        public const String Maestro_usp_Estado_Modificar = "Maestro.usp_Estado_Modificar";
        public const String Maestro_usp_Estado_Eliminar = "Maestro.usp_Estado_Eliminar";

        //Maestro.Contacto
        public const String Maestro_usp_Contacto_Obtener = "Maestro.usp_Contacto_Obtener";
        public const String Maestro_usp_Contacto_Combo = "Maestro.usp_Contacto_Combo";
        public const String Maestro_usp_Contacto_ObtenerPorId = "Maestro.usp_Contacto_ObtenerPorId";
        public const String Maestro_usp_Contacto_Registrar = "Maestro.usp_Contacto_Registrar";
        public const String Maestro_usp_Contacto_Modificar = "Maestro.usp_Contacto_Modificar";
        public const String Maestro_usp_Contacto_Eliminar = "Maestro.usp_Contacto_Eliminar";

        //Maestro.Pais
        public const String Maestro_usp_Pais_Obtener = "Maestro.usp_Pais_Obtener";
        public const String Maestro_usp_Pais_Combo = "Maestro.usp_Pais_Combo";
        public const String Maestro_usp_Pais_ObtenerPorId = "Maestro.usp_Pais_ObtenerPorId";
        public const String Maestro_usp_Pais_Registrar = "Maestro.usp_Pais_Registrar";
        public const String Maestro_usp_Pais_Modificar = "Maestro.usp_Pais_Modificar";
        public const String Maestro_usp_Pais_Eliminar = "Maestro.usp_Pais_Eliminar";

        //Maestro.Ubigeo
        public const String Maestro_usp_Ubigeo_Combo = "Maestro.usp_Ubigeo_Combo";

        //Gestion.Faq
        public const String Gestion_usp_Faq_Obtener = "Gestion.usp_Faq_Obtener";
        public const String Gestion_usp_Faq_Combo = "Gestion.usp_Faq_Combo";
        public const String Gestion_usp_Faq_ObtenerPorId = "Gestion.usp_Faq_ObtenerPorId";
        public const String Gestion_usp_Faq_Registrar = "Gestion.usp_Faq_Registrar";
        public const String Gestion_usp_Faq_Modificar = "Gestion.usp_Faq_Modificar";
        public const String Gestion_usp_Faq_Eliminar = "Gestion.usp_Faq_Eliminar";

        //Gestion.Incidencia
        public const String Gestion_usp_Incidencia_Obtener = "Gestion.usp_Incidencia_Obtener";
        public const String Gestion_usp_Incidencia_Combo = "Gestion.usp_Incidencia_Combo";
        public const String Gestion_usp_Incidencia_ObtenerPorId = "Gestion.usp_Incidencia_ObtenerPorId";
        public const String Gestion_usp_Incidencia_Registrar = "Gestion.usp_Incidencia_Registrar";
        public const String Gestion_usp_Incidencia_Modificar = "Gestion.usp_Incidencia_Modificar";
        public const String Gestion_usp_Incidencia_Eliminar = "Gestion.usp_Incidencia_Eliminar";
        public const String Gestion_usp_Incidencia_ObtenerHistorial = "Gestion.usp_Incidencia_ObtenerHistorial";
        public const String Gestion_usp_Incidencia_ObtenerPorId_Detallado = "Gestion.usp_Incidencia_ObtenerPorId_Detallado";
        public const String Gestion_usp_Incidencia_ModificarEstado = "Gestion.usp_Incidencia_ModificarEstado";

        //Gestion.IncidenciaDetalle
        public const String Gestion_usp_IncidenciaDetalle_Obtener = "Gestion.usp_IncidenciaDetalle_Obtener";
        public const String Gestion_usp_IncidenciaDetalle_Combo = "Gestion.usp_IncidenciaDetalle_Combo";
        public const String Gestion_usp_IncidenciaDetalle_ObtenerPorId = "Gestion.usp_IncidenciaDetalle_ObtenerPorId";
        public const String Gestion_usp_IncidenciaDetalle_Registrar = "Gestion.usp_IncidenciaDetalle_Registrar";
        public const String Gestion_usp_IncidenciaDetalle_Modificar = "Gestion.usp_IncidenciaDetalle_Modificar";
        public const String Gestion_usp_IncidenciaDetalle_Eliminar = "Gestion.usp_IncidenciaDetalle_Eliminar";

    }
}
