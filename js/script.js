$(document).ready(function () {
    new DataTable($("#ContentPlaceHolder1_GridView1"),
    //new DataTable($("#GridView1"),
    {
        responsive: true,
        
        });

    //new DataTable('#GridView1', {
    //    layout: {
    //        bottomEnd: {
    //            paging: {
    //                firstLast: false
    //            }
    //        }
    //    }
    //});
    //$(document).ready(function () {
    //    $('#<%= GridView1.ClientID%>').DataTable();
    //});

  $("#btnMenu").click(function () {
    $("#buttonContainer ").addClass("showButtons");
  });
  //$("#btnClose").click(function () {
  //  $("#buttonContainer ").removeClass("showButtons");
  //});
});

//$(document).ready(function () {
//    new DataTable('#<%= GridView1.ClientID%>', {
//        responsive: true,
//    })
//});
function clickMenu() {
  $("#buttonContainer ").removeClass("showButtons");
}
//$(".menu-button").click(function () {
//    alert('1');
//    //$(".menu-item").removeClass("menu-button.active");
//    //$(this).addClass("menu-button.active");
//    $(this).addClass('active');
//    $(this).siblings().removeClass('active');
//})