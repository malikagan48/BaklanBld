/**
 * @license Copyright (c) 2003-2022, CKSource Holding sp. z o.o. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
    config.filebrowserImageUploadUrl = '/Content/Resimler/'; //Resmin yükleneceği site adresi
    config.fileTools_requestHeaders = { 'X-CSRFToken': '{{ @GetAntiXsrfRequestToken() }}' };
    config.removePlugins = 'easyimage,cloudservices';
};
