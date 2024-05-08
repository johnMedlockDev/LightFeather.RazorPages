$(document).ready(function () {
	function toggleInput(input, checkbox) {
		input.prop('disabled', !checkbox.prop('checked'));
	}

	const phoneCheckBox = $("#PhoneCheckBox");
	const phoneInput = $("#PhoneInput");

	toggleInput(phoneInput, phoneCheckBox);
	phoneCheckBox.change(function () {
		toggleInput(phoneInput, phoneCheckBox)
	});

	const emailCheckBox = $("#EmailCheckBox");
	const emailInput = $("#EmailInput");

	toggleInput(emailInput, emailCheckBox);
	emailCheckBox.change(function () {
		toggleInput(emailInput, emailCheckBox)
	});
});