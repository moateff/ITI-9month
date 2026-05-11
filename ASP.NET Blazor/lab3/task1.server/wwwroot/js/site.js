window.blazorInterop = {

    showAlert: function (message) {
        alert(message);
    }
};

window.callDotNetMethod = async function () {

    await DotNet.invokeMethodAsync('task1.server', 'GetCurrentTime')
            .then(result => {
                console.log(result);
                alert("Current Time: " + result);
            }).catch(error => {
                console.error(error);
            })
}
