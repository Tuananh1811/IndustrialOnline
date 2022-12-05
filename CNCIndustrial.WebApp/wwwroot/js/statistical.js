document.addEventListener('scroll', function() {
    animateNumber(456043, 2000, 100000, function(number) {
        const formattedNumber = number.toLocaleString()
        document.getElementById('leased-area').innerText = formattedNumber
    })

    animateNumber(494111, 3000, 100000, function(number) {
        const formattedNumber = number.toLocaleString()
        document.getElementById('sold-area').innerText = formattedNumber
    })

    animateNumber(2883452, 4000, 1000000, function(number) {
        const formattedNumber = number.toLocaleString()
        document.getElementById('values-tran').innerText = formattedNumber
    })
    animateNumber(60, 1400, 0, function(number) {
        const formattedNumber = number.toLocaleString()
        document.getElementById('developer-contracts').innerText = formattedNumber + new String("+")
    })
})