var cart = [];

function addToCart(id, name, price) {
    var item = {
        id: id,
        name: name,
        price: price,
        quantity: 1
    };

    var existingItem = cart.find(function (i) { return i.id === id; });

    if (existingItem) {
        existingItem.quantity++;
    } else {
        cart.push(item);
       

    }

    saveCart();
    alert("Thêm thành công sản phẩm")
    
}



function clearCart() {
    cart = [];
    saveCart();
}

function getCart() {
    return cart;
}

function getTotal() {
    var total = 0;

    cart.forEach(function (item) {
        total += item.price * item.quantity;
    });

    return total;
}
function totalCart(cart) {
    const totalCount = cart.reduce((accumulator, currentProduct) => {
        return accumulator + currentProduct.quantity;
    }, 0);
    return totalCount;
}

function saveCart() {
    localStorage.setItem('cart', JSON.stringify(cart));
}

function loadCart() {
    cart = JSON.parse(localStorage.getItem('cart')) || [];
}

loadCart();
