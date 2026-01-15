function addToBasket(productId) {
    fetch('/Basket/Add?id=' + productId, {
        method: 'POST'
    })
        .then(response => {
            if (response.ok) {
                alert('Product Added to Cart!');
                updateCartCount();
            } else {
                response.text().then(text => {
                    console.error('Error response:', text);
                    alert('Failed');
                });
            }
        })
        .catch(error => {
            console.error('Error:', error);
            alert('An error occurred');
        });
}
function removeFromBasket(productId, element) {
    fetch('/Basket/Remove?id=' + productId, {
        method: 'POST'
    })
        .then(response => {
            if (response.ok) {
                element.closest('tr').remove();
                location.reload();
            } else {
                alert('Failed to remove product from cart');
            }
        })
        .catch(error => {
            console.error('Error:', error);
            alert('An error occurred');
        });
}

function changeQuantity(productId, change) {
    fetch(`/Cart/ChangeQuantity?productId=${productId}&change=${change}`, {
        method: 'POST'
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                document.getElementById('cartContainer').innerHTML = data.cartHtml;
            } else {
                alert('Failed to update quantity');
            }
        })
        .catch(error => {
            console.error('Error:', error);
            alert('An error occurred');
        });
}

function updateCartCount() {
    fetch('/Basket/GetBasket')
        .then(response => response.json())
        .then(data => {
            const cartCountElement = document.querySelector('.cart-count');
            if (cartCountElement) {
                cartCountElement.textContent = data.totalCount;
            }
        })
        .catch(error => console.error('Error:', error));
}