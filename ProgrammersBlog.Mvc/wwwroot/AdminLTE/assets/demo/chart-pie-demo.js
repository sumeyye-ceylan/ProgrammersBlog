$.get('/Home/LoadPie/').done(function (result) {

    var res = jQuery.parseJSON(result);

    // Set new default font family and font color to mimic Bootstrap's default styling
    Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
    Chart.defaults.global.defaultFontColor = '#292b2c';

    // Pie Chart Example
    var ctx = document.getElementById("myPieChart");
    var myPieChart = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: ["Sipariş Onayında","Kesim Onayında", "Dikim Onayında", "Ütü-Paket Onayında", "Tamamlandı"],
            datasets: [{
                data: [res.OrderApproveCount, res.CutApproveCount, res.StitchApproveCount, res.PackApproveCount, res.CompletedOrderCount],
                backgroundColor: ['#dc3545', '#007bff', '#7A0BC0', '#FFC900', '#28a745'],
            }],
        },
    });

}).fail(function () {
    toastr.error("Pasta grafik yüklenirken bir hata oluştu.");
});






