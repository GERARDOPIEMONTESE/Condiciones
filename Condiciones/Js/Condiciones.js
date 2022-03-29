function Cerrar() {
    window.close();
}
function Redireccionar() {
    window.location = 'http://portal.assist-card.com/Usuarios/LogIn.aspx';

}
function RedireccionarConTiempo() {

    setTimeout("Redireccionar()", 8000);

}