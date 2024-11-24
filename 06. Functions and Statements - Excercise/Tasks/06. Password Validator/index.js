function validation(password){
    const digitsAndLetters = new RegExp(/^[a-zA-Z0-9]+$/);
    const atLeast2Digits = new RegExp(/(.*\d){2}/);
    let valid = 0;
    if(password.length < 6 || password.length > 10) console.log('Password must be between 6 and 10 characters');
    else valid++;
    if(!digitsAndLetters.test(password)) console.log('Password must consist only of letters and digits');
    else valid++;
    if(!atLeast2Digits.test(password)) console.log('Password must have at least 2 digits');
    else valid++;

    if(valid === 3) console.log('Password is valid');
}
validation('logIn');
validation('Pa$s$s');
validation('MyPass123');