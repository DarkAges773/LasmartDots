var $ = require("jquery");
import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import '@progress/kendo-ui';
import '@progress/kendo-ui/css/web/kendo.default.min.css';
import '@progress/kendo-ui/css/web/kendo.common.min.css';
export { Canvas } from './Models/Canvas';

KendoLicensing.setScriptKey(
    '141j044b041h541j4i1d542e58285k264c22502j5f465d3858385d3g6139' +
    '5j3g5g414g2f4g395109544b544027012c161e121h122g0e2d402c161e0h' +
    '1e0i300d2h495144504555462e0b4k3b4i3510531143235b164805573907' +
    '263j5g265b245j432k412c51365c022g071g5f'
);

$(document).ready(() => {
	$('.color-picker').kendoColorPicker()
})
