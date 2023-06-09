function SelectEmployees(appendId) {
    $(document).ready(function () {
        $.ajax({
            method: "get",
            url: "/Employee/GetEmployeeModels",
            success: function (data) {
                console.log(data);
                $.each(data, function (i, item) {
                    var html = '<option value="' + data[i].id + '">' + data[i].fullName + '</option>';
                    console.log(html);
                    $(appendId).append(html);
                })
            }
        });
    });
};
