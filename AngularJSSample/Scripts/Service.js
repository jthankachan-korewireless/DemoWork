//app.service("personInfoService", function ($http) {

//    this.getInfo = function (id) {
//        var req = $http.get('/api/PersonInformationAPI/' + id);
//        return req;
//    };

//    this.getAppInfo = function () {
//        var req = $http.get('/api/PersonInformationAPI');
//        return req;
//    }

//    this.postInfo = function (personInfo) {
//        var req = $http.post('/api/PersonInformationAPI', personInfo);
//        return req;
//    };

//});

myApp.service("LoginService", function ($http) {

    var fact = {};
    fact.getUserDetails = function (d) {
        debugger;
        return $http({
            url: 'SampleData.asmx/GetLoginDetails',
            method: 'POST',
            data: JSON.stringify(d),
            headers: { 'content-type': 'application/json' }
        });
    };
    fact.SetPassword = function (d) {
        debugger;
        return $http({
            url: '/Login/SetPassword',
            method: 'POST',
            data: JSON.stringify(d),
            headers: { 'content-type': 'application/json' }
        });
    };
    return fact;
});