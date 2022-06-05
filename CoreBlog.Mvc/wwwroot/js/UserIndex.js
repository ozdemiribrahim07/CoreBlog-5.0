

$(document).ready(function () {
    const datatable = $('#usertable').DataTable({

        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
            {
                text: 'Ekle',
                attr: {
                    id: "btnEkle"
                },
                className: 'btn btn-success',
                action: function (e, dt, node, config) {

                }
            },

        ],
        language: {
            "emptyTable": "Tabloda herhangi bir veri mevcut değil",
            "info": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
            "infoEmpty": "Kayıt yok",
            "infoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
            "infoThousands": ".",
            "lengthMenu": "Sayfada _MENU_ kayıt göster",
            "loadingRecords": "Yükleniyor...",
            "processing": "İşleniyor...",
            "search": "Ara:",
            "zeroRecords": "Eşleşen kayıt bulunamadı",
            "paginate": {
                "first": "İlk",
                "last": "Son",
                "next": "Sonraki",
                "previous": "Önceki"
            },
            "aria": {
                "sortAscending": ": artan sütun sıralamasını aktifleştir",
                "sortDescending": ": azalan sütun sıralamasını aktifleştir"
            },
            "select": {
                "rows": {
                    "_": "%d kayıt seçildi",
                    "1": "1 kayıt seçildi"
                },
                "cells": {
                    "1": "1 hücre seçildi",
                    "_": "%d hücre seçildi"
                },
                "columns": {
                    "1": "1 sütun seçildi",
                    "_": "%d sütun seçildi"
                }
            },
            "autoFill": {
                "cancel": "İptal",
                "fillHorizontal": "Hücreleri yatay olarak doldur",
                "fillVertical": "Hücreleri dikey olarak doldur",
                "fill": "Bütün hücreleri <i>%d<\/i> ile doldur"
            },
            "buttons": {
                "collection": "Koleksiyon <span class=\"ui-button-icon-primary ui-icon ui-icon-triangle-1-s\"><\/span>",
                "colvis": "Sütun görünürlüğü",
                "colvisRestore": "Görünürlüğü eski haline getir",
                "copySuccess": {
                    "1": "1 satır panoya kopyalandı",
                    "_": "%ds satır panoya kopyalandı"
                },
                "copyTitle": "Panoya kopyala",
                "csv": "CSV",
                "excel": "Excel",
                "pageLength": {
                    "-1": "Bütün satırları göster",
                    "_": "%d satır göster"
                },
                "pdf": "PDF",
                "print": "Yazdır",
                "copy": "Kopyala",
                "copyKeys": "Tablodaki veriyi kopyalamak için CTRL veya u2318 + C tuşlarına basınız. İptal etmek için bu mesaja tıklayın veya escape tuşuna basın.",
                "createState": "Şuanki Görünümü Kaydet",
                "removeAllStates": "Tüm Görünümleri Sil",
                "removeState": "Aktif Görünümü Sil",
                "renameState": "Aktif Görünümün Adını Değiştir",
                "savedStates": "Kaydedilmiş Görünümler",
                "stateRestore": "Görünüm -&gt; %d",
                "updateState": "Aktif Görünümün Güncelle"
            },
            "searchBuilder": {
                "add": "Koşul Ekle",
                "button": {
                    "0": "Arama Oluşturucu",
                    "_": "Arama Oluşturucu (%d)"
                },
                "condition": "Koşul",
                "conditions": {
                    "date": {
                        "after": "Sonra",
                        "before": "Önce",
                        "between": "Arasında",
                        "empty": "Boş",
                        "equals": "Eşittir",
                        "not": "Değildir",
                        "notBetween": "Dışında",
                        "notEmpty": "Dolu"
                    },
                    "number": {
                        "between": "Arasında",
                        "empty": "Boş",
                        "equals": "Eşittir",
                        "gt": "Büyüktür",
                        "gte": "Büyük eşittir",
                        "lt": "Küçüktür",
                        "lte": "Küçük eşittir",
                        "not": "Değildir",
                        "notBetween": "Dışında",
                        "notEmpty": "Dolu"
                    },
                    "string": {
                        "contains": "İçerir",
                        "empty": "Boş",
                        "endsWith": "İle biter",
                        "equals": "Eşittir",
                        "not": "Değildir",
                        "notEmpty": "Dolu",
                        "startsWith": "İle başlar",
                        "notContains": "İçermeyen",
                        "notStarts": "Başlamayan",
                        "notEnds": "Bitmeyen"
                    },
                    "array": {
                        "contains": "İçerir",
                        "empty": "Boş",
                        "equals": "Eşittir",
                        "not": "Değildir",
                        "notEmpty": "Dolu",
                        "without": "Hariç"
                    }
                },
                "data": "Veri",
                "deleteTitle": "Filtreleme kuralını silin",
                "leftTitle": "Kriteri dışarı çıkart",
                "logicAnd": "ve",
                "logicOr": "veya",
                "rightTitle": "Kriteri içeri al",
                "title": {
                    "0": "Arama Oluşturucu",
                    "_": "Arama Oluşturucu (%d)"
                },
                "value": "Değer",
                "clearAll": "Filtreleri Temizle"
            },
            "searchPanes": {
                "clearMessage": "Hepsini Temizle",
                "collapse": {
                    "0": "Arama Bölmesi",
                    "_": "Arama Bölmesi (%d)"
                },
                "count": "{total}",
                "countFiltered": "{shown}\/{total}",
                "emptyPanes": "Arama Bölmesi yok",
                "loadMessage": "Arama Bölmeleri yükleniyor ...",
                "title": "Etkin filtreler - %d",
                "showMessage": "Tümünü Göster",
                "collapseMessage": "Tümünü Gizle"
            },
            "thousands": ".",
            "datetime": {
                "amPm": [
                    "öö",
                    "ös"
                ],
                "hours": "Saat",
                "minutes": "Dakika",
                "next": "Sonraki",
                "previous": "Önceki",
                "seconds": "Saniye",
                "unknown": "Bilinmeyen",
                "weekdays": {
                    "6": "Paz",
                    "5": "Cmt",
                    "4": "Cum",
                    "3": "Per",
                    "2": "Çar",
                    "1": "Sal",
                    "0": "Pzt"
                },
                "months": {
                    "9": "Ekim",
                    "8": "Eylül",
                    "7": "Ağustos",
                    "6": "Temmuz",
                    "5": "Haziran",
                    "4": "Mayıs",
                    "3": "Nisan",
                    "2": "Mart",
                    "11": "Aralık",
                    "10": "Kasım",
                    "1": "Şubat",
                    "0": "Ocak"
                }
            },
            "decimal": ",",
            "editor": {
                "close": "Kapat",
                "create": {
                    "button": "Yeni",
                    "submit": "Kaydet",
                    "title": "Yeni kayıt oluştur"
                },
                "edit": {
                    "button": "Düzenle",
                    "submit": "Güncelle",
                    "title": "Kaydı düzenle"
                },
                "error": {
                    "system": "Bir sistem hatası oluştu (Ayrıntılı bilgi)"
                },
                "multi": {
                    "info": "Seçili kayıtlar bu alanda farklı değerler içeriyor. Seçili kayıtların hepsinde bu alana aynı değeri atamak için buraya tıklayın; aksi halde her kayıt bu alanda kendi değerini koruyacak.",
                    "noMulti": "Bu alan bir grup olarak değil ancak tekil olarak düzenlenebilir.",
                    "restore": "Değişiklikleri geri al",
                    "title": "Çoklu değer"
                },
                "remove": {
                    "button": "Sil",
                    "confirm": {
                        "_": "%d adet kaydı silmek istediğinize emin misiniz?",
                        "1": "Bu kaydı silmek istediğinizden emin misiniz?"
                    },
                    "submit": "Sil",
                    "title": "Kayıtları sil"
                }
            },
            "stateRestore": {
                "creationModal": {
                    "button": "Kaydet",
                    "columns": {
                        "search": "Kolon Araması",
                        "visible": "Kolon Görünümü"
                    },
                    "name": "Görünüm İsmi",
                    "order": "Sıralama",
                    "paging": "Sayfalama",
                    "scroller": "Kaydırma (Scrool)",
                    "search": "Arama",
                    "searchBuilder": "Arama Oluşturucu",
                    "select": "Seçimler",
                    "title": "Yeni Görünüm Oluştur",
                    "toggleLabel": "Kaydedilecek Olanlar"
                },
                "duplicateError": "Bu Görünüm Daha Önce Tanımlanmış",
                "emptyError": "Görünüm Boş Olamaz",
                "emptyStates": "Herhangi Bir Görünüm Yok",
                "removeConfirm": "Görünümü Silmek İstediğinize Eminminisiniz?",
                "removeError": "Görünüm Silinemedi",
                "removeJoiner": "ve",
                "removeSubmit": "Sil",
                "removeTitle": "Görünüm Sil",
                "renameButton": "Değiştir",
                "renameLabel": "Görünüme Yeni İsim Ver -&gt; %s:",
                "renameTitle": "Görünüm İsmini Değiştir"
            }
        }

    });

    // AJAX GET
    //Partial view'i aldık ve ekranda gösterdik.
    $(function () {
        const url = '/Admin/User/Add/'; // gitmek istediğimiz action'u url'ye atadık.
        const placeholder = $('#addpartial');  //div'i değişken içine attık.
        $('#btnEkle').click(function () {
            $.get(url).done(function (data) {  // partial viewi aldık ve div'in içerisine yazdık.
                placeholder.html(data);
                placeholder.find(".modal").modal('show');  //bootstrap olarak eklediğimiz class'ı bul ve modal yap.
            });
        });


        //AJAX POST
        placeholder.on('click', '#btnekle', function (event) {
            event.preventDefault();                     // butonun kendi click işlevini engelledik.
            const form = $('#kullanıcıadd');            //partial içindeki form id'yi veriyoruz.
            const dataurl = form.attr('action');           //url olarak form içindeki asp-action alıyoruz.

            const datasend = new FormData(form.get(0));
            $.ajax({

                url: dataurl,
                type: 'POST',
                data: datasend,
                processData: false,
                contentType: false,
                success: function (data) {
                    console.log(data);
                    const userajax = jQuery.parseJSON(data);
                    console.log(userajax);
                    const body = $('.modal-body', userajax.UserAddPartial);     //partial içindeki div class'ını aldık.
                    placeholder.find('.modal-body').replaceWith(body);
                    const valid = body.find('[name="IsValid"]').val() === 'True';
                    if (valid) {
                        placeholder.find('.modal').modal('hide');

                        const newrow = table.row.add([
                            userajax.UserDto.User.Id,
                            userajax.UserDto.User.UserName,
                            userajax.UserDto.User.Email,
                            `<img src="/userimages/${userajax.UserDto.User.Picture}" style="max-height:50px; max-width:50px;" />`,
                            `<td>
                                    <button class="btn btn-primary btn-sm btn-block btn-guncelle" data-id="userajax.UserDto.User.Id">Güncelle</button>
                                    <button class="btn btn-danger btn-sm btn-block btn-sil" data-id="userajax.UserDto.User.Id">Sil</button>

                              </td> `



                        ]).node();

                        const jqueryrow = $(newrow);
                        jqueryrow.attr('name', `${userajax.UserDto.User.Id}`);
                        datatable.row(newrow).draw();

                        toastr.success(`${userajax.UserDto.Message}`, 'Başarılı !')
                    }
                    else {
                        let txt = "";
                        $('#validation > ul > li').each(function () {
                            let text = $(this).text();
                            txt = `${text}\n`;
                        });
                        toastr.warning(txt);

                    }

                },
                error: function (err) {
                    console.log(err);
                }

            });

        });

    });

    // AJAX POST DELETE
    $(document).on('click', '.btn-sil', function (event) {
        event.preventDefault();
        const id = $(this).attr('data-id');
        const tablerow = $(`[name="${id}"]`);
        const username = tablerow.find('td:eq(1)').text();
        Swal.fire({
            title: 'Silmek istediğine emin misin?',
            text: `${username} geri getiremeyeceksin!`,
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Evet, Sil',
            cancelButtonText: 'Hayır, Silmek istemiyorum.'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    data: { userid: id },
                    url: '/Admin/User/Delete/',
                    success: function (data) {
                        const userDto = jQuery.parseJSON(data);
                        if (userDto.SonucStatus === 1) {
                            Swal.fire(
                                'Silindi!',
                                'Kullanıcı silindi.',
                                'success'
                            );

                            table.row(tablerow).remove().draw();
                        }
                        else {
                            Swal.fire({
                                icon: 'error',
                                title: 'Başarısız !',

                            });
                        }
                    },
                    error: function (err) { console.log(err); }

                })
            }
        })


    });


    // USER UPDATE AJAX GET
    $(function () {
        const url = '/Admin/User/Update/';
        const placeholder = $('#addpartial');
        $(document).on('click',
            '.btn-guncelle',
            function (event) {
                event.preventDefault();
                const id = $(this).attr('data-id');
                $.get(url, { userid: id }).done(function (data) {

                    placeholder.html(data);
                    placeholder.find('.modal').modal('show');


                }).fail(function () {
                    toastr.error("HATA");
                });
            });

        // USER UPDATE AJAX POST
        placeholder.on('click',
            '#btnguncelle',
            function (event) {
                event.preventDefault();

                const form = $('#userupdate');
                const actionurl = form.attr('action');
                const datasend = new FormData(form.get(0));
                $.ajax({

                    url: actionurl,
                    type: 'POST',
                    data: datasend,
                    processData: false,
                    contentType: false,
                    success: function (data) {

                        const userajaxupdate = jQuery.parseJSON(data);
                        console.log(userajaxupdate);
                        const idno = userajaxupdate.UserDto.User.Id;
                        const tablerow = $(`[name="${idno}"]`);
                        const formbody = $('.modal-body', userajaxupdate.UserUpdatePartial);

                        placeholder.find('.modal-body').replaceWith(formbody);
                        const isValid = formbody.find('[name="IsValid"]').val() === 'True';
                        if (isValid) {
                            placeholder.find('.modal').modal('hide');
                            datatable.row(tablerow).data([
                                userajaxupdate.UserDto.User.Id,
                                userajaxupdate.UserDto.User.UserName,
                                userajaxupdate.UserDto.User.Email,
                                `<img src="/userimages/${userajaxupdate.UserDto.User.Picture}" style="max-height:50px; max-width:50px;" />`,
                                `
                                    <button class="btn btn-primary btn-sm btn-block btn-guncelle" data-id="${userajaxupdate.UserDto.User.Id}">Güncelle</button>
                                    <button class="btn btn-danger btn-sm btn-block btn-sil" data-id="${userajaxupdate.UserDto.User.Id}">Sil</button>

                               `



                            ]);

                            tablerow.attr("name", `${idno}`);
                            datatable.row(tablerow).invalidate();


                            toastr.success(`${userajaxupdate.UserDto.Message}`, "Başarılı !");

                        } else {
                            let txt = "";
                            $('#validation > ul > li').each(function () {
                                let text = $(this).text();
                                txt = `*${text}\n`;
                            });
                            toastr.warning(txt);
                        }


                    },
                    error: function (error) {
                        console.log(error);
                    }

                });


            });



    });

    $(function () {
        const url = '/Admin/Role/Assign/';
        const placeHolderDiv = $('#addpartial');
        $(document).on('click',
            '.btn-ata',
            function (event) {
                event.preventDefault();
                const id = $(this).attr('data-id');
                $.get(url, { Userid: id }).done(function (data) {
                    placeHolderDiv.html(data);
                    placeHolderDiv.find('.modal').modal('show');
                }).fail(function (err) {
                    toastr.error(`${err.responseText}`, 'Hata!');
                });
            });


    });



});