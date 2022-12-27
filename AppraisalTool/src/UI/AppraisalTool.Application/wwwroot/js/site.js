// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

(function () {
    'use strict'

    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.querySelectorAll('.loginPageForm')

    // Loop over them and prevent submission
    Array.prototype.slice.call(forms)
        .forEach(function (form) {
            form.addEventListener('submit', function (event) {
                if (!form.checkValidity()) {
                    event.preventDefault()
                    event.stopPropagation()
                }
                let Pattern = /^[A-Z0-9]{4}$/;
                let captcha = document.getElementById("captchaCode");


                form.classList.add('was-validated')

                let email = document.getElementById("exampleInputEmail1");
                let EMAILpattern = /^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4})*$/;
                if (email.value == null || email.value == undefined || email.value == "") {

                    email.classList.add('is-invalid');
                }
                if (!EMAILpattern.test(email.value)) {
                    form.classList.remove('was-validated')
                    email.classList.remove('is-valid');
                    email.classList.add('is-invalid');
                    event.preventDefault()
                    event.stopPropagation()
                }
                let password = document.getElementById("exampleInputPassword1");
                let Passwordpattern = /^[a-zA-Z0-9@&*$]{8,50}$/;
                if (!Passwordpattern.test(password.value)) {
                    form.classList.remove('was-validated')
                    password.classList.remove('is-valid');
                    password.classList.add('is-invalid');
                    event.preventDefault()
                    event.stopPropagation()
                }
                if (!Pattern.test(captcha.value)) {
                    form.classList.remove('was-validated')
                    captcha.classList.remove('is-valid');
                    captcha.classList.add('is-invalid');
                    event.preventDefault()
                    event.stopPropagation()
                }
                
            }, false)
        })
})()
//document.addEventListener("DOMContentLoaded", function (event) {

//alert("dom alert")
//})
//document.getElementById("loginBtn").addEventListener("click", () => {
//    console.log("button Clicked");
//})
//document.getElementById("loginForm").addEventListener('submit', (event) => {
//    alert("submit")
//    //let email = document.getElementById("exampleInputEmail1");
//    //let pattern = /^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4})*$/;
//    //if (pattern.test(document.getElementById("exampleInputEmail1").value)) {
//    //    email.classList.remove('is-invalid');
//    //    email.classList.add('is-valid');
//    //}
//    //else {

//    //    document.getElementById("loginForm").classList.remove('was-validated');
//    //    document.getElementById("exampleInputEmail1").classList.remove('is-valid');
//    //    document.getElementById("exampleInputEmail1").classList.add('is-invalid');
//    //    document.getElementById("loginForm").addEventListener('submit', (event) => {
//    //        event.preventDefault()
//    //        event.stopPropagation()

//    //    })
//    //}

    

//})
let email = document.getElementById("exampleInputEmail1");

//if (email.value = null) {
//    email.classList.remove('is-valid');
//    email.classList.add('is-invalid');
//}
email.addEventListener("keyup", () => {
    
    /*  alert(document.getElementById("exampleInputEmail1").value);*/
    let pattern = /^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4})*$/;

;


    if (pattern.test(document.getElementById("exampleInputEmail1").value)) {
        if (document.getElementById("exampleInputEmail1").value == null || document.getElementById("exampleInputEmail1").value == undefined || document.getElementById("exampleInputEmail1").value == "") {

            console.log("not same 1");
            let loginform = document.getElementById("loginForm");
            loginform.classList.remove('was-validated');
            email.classList.remove('is-invalid');
            email.classList.remove('is-valid');
            email.classList.add('is-invalid');
        }
        else {

            email.classList.remove('is-invalid');
            email.classList.add('is-valid');
        }
       
       /* alert("valid");*/
    }
    else {
        console.log("not same 2");
        document.getElementById("loginForm").classList.remove('was-validated');
        document.getElementById("exampleInputEmail1").classList.remove('is-valid');
        document.getElementById("exampleInputEmail1").classList.add('is-invalid');
        //document.getElementById("loginForm").addEventListener('submit', (event) => {
        //    event.preventDefault()
        //    event.stopPropagation()

        //})

        
    }
});
// Write your JavaScript code.
let password = document.getElementById("exampleInputPassword1");
password.addEventListener("keyup", () => {

    let pattern = /^[a-zA-Z0-9@&*$]{8,50}$/;

    if (pattern.test(document.getElementById("exampleInputPassword1").value)) {
        if (document.getElementById("exampleInputPassword1").value == null || document.getElementById("exampleInputPassword1").value == undefined || document.getElementById("exampleInputPassword1").value == "") {

            password.classList.remove('is-valid');
            password.classList.add('is-invalid');
        }
        else {

            password.classList.remove('is-invalid');
            password.classList.add('is-valid');
        }

        /* alert("valid");*/
    }
    else {
        password.classList.remove('is-valid');
        password.classList.add('is-invalid');
        document.getElementById("loginForm").classList.remove('was-validated');

    }
    



});

let captcha = document.getElementById("captchaCode");
captcha.addEventListener("keyup", () => {
    let Pattern = /^[A-Z0-9]{4}$/;
    if (Pattern.test(document.getElementById("captchaCode").value)) {
        if (document.getElementById("captchaCode").value == null || document.getElementById("captchaCode").value == undefined || document.getElementById("captchaCode").value == "") {

            captcha.classList.remove('is-valid');
           captcha.classList.add('is-invalid');
        }
        else {
            
            captcha.classList.remove('is-invalid');
           captcha.classList.add('is-valid');
        }
    }
    else {
        document.getElementById("loginForm").classList.remove('was-validated');
       captcha.classList.remove('is-valid');
        captcha.classList.add('is-invalid');
       //document.getElementById("loginForm").addEventListener('submit', (event) => {
       //     event.preventDefault()
       //   /* event.stopPropagation()*/
       // })

    }

   
})

//captcha.addEventListener("keyup", () => {

//    let Pattern = /^[A-Z0-9]{4}$/;

//    if (pattern.test(document.getElementById("captchaCode").value)) {
//        if (document.getElementById("captchaCode").value == null || document.getElementById("captchaCode").value == undefined || document.getElementById("captchaCode").value == "") {

//            captcha.classList.remove('is-valid');
//            captcha.classList.add('is-invalid');
//        }
//        else {
//            alert("Matched")
//            captcha.classList.remove('is-invalid');
//            captcha.classList.add('is-valid');
//        }

//        /* alert("valid");*/
//    }
//    else {
//        alert("Doesnot Match")
//        captcha.classList.remove('is-valid');
//        captcha.classList.add('is-invalid');

//    }


//});


