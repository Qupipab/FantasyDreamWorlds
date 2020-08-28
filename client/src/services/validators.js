export function trueCheck (value) {
  return value === true;
}

export function haveUppercase (value) {
  return /[A-Z]/.test(value);
}

export function haveNum (value) {
  return /[0-9]/.test(value);
}
