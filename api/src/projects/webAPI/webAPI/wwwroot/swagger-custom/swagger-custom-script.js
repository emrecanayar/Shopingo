(function () {
    window.addEventListener("load", function () {
        setTimeout(function () {
            var logo = document.getElementsByClassName('link');
            logo[0].href = "https://emrecanayar.com";
            logo[0].target = "_blank";
            logo[0].children[0].alt = "Implemeting Swagger";
            logo[0].children[0].src = "../swagger-custom/logo-icon.png";

            var spans = document.getElementsByTagName("span");

            for (var i = 0; i < spans.length; i++) {
                if (spans[i].textContent.includes("Select a definition")) {
                    spans[i].classList.add("custom-span");
                }
            }
        });
    });

})();

document.addEventListener("DOMContentLoaded", function () {
    // DOM'un y�klendi�inden emin olmak i�in k�sa bir gecikme ekleyin
    setTimeout(function () {
        const authorizeButton = document.querySelector('.btn.authorize.locked');
        console.log(authorizeButton);

        // E�er token zaten localStorage'da varsa kullan.
        const existingToken = localStorage.getItem('swagger_access_token');
        if (existingToken) {
            window.ui.authActions.authorize({
                'Bearer': {
                    name: 'Bearer',
                    schema: {
                        type: 'apiKey',
                        in: 'header',
                        name: 'Authorization',
                        description: ''
                    },
                    value: `Bearer ${existingToken}`
                }
            });
        }

        // Ana "Authorize" butonuna t�kland���nda �al��acak olan fonksiyon
        if (authorizeButton) {
            authorizeButton.onclick = () => {
                // Modal�n a��lmas�na izin vermek i�in k�sa bir gecikme ekleyin
                setTimeout(() => {
                    const modalAuthorizeButton = document.querySelector('.modal-ux .auth-btn-wrapper .btn.modal-btn.auth.authorize.button');
                    if (modalAuthorizeButton) {
                        modalAuthorizeButton.onclick = () => {
                            setTimeout(() => {
                                const tokenInput = document.querySelector('.modal-ux .auth-container input[type="text"]');
                                if (tokenInput) {
                                    const tokenValue = tokenInput.value;
                                    if (tokenValue.startsWith('Bearer ')) {
                                        // Token de�erini localStorage'a kaydet
                                        localStorage.setItem('swagger_access_token', tokenValue.substring(7));
                                    }
                                }
                            }, 500);
                        };
                    }
                }, 500);
            };
        }
    }, 1000); // 1 saniye gecikme
});
