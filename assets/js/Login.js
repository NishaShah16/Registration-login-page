$(document).ready(function () {

    $("#loginBy").change(function () {
        if ($("#loginBy").val() == "NHQ Admin") {
            $("#btnSubmit").attr("href", "NHQ/Dashboard.html")
        } else if ($("#loginBy").val() == "State Center") {
            $("#btnSubmit").attr("href", "StateCenter/Dashboard.html")
        } else if ($("#loginBy").val() == "District / Training Center") {
            $("#btnSubmit").attr("href", "TrainingCenter/Dashboard.html")
        } else if ($("#loginBy").val() == "Corporates") {
            $("#btnSubmit").attr("href", "Corporates/Dashboard.html")
        } else if ($("#loginBy").val() == "School") {
            $("#btnSubmit").attr("href", "School/Dashboard.html")
        } else if ($("#loginBy").val() == "Individuals") {
            $("#btnSubmit").attr("href", "Candidate/Dashboard.html")
        } else if ($("#loginBy").val() == "Student") {
            $("#btnSubmit").attr("href", "Student/Dashboard.html")
        } else if ($("#loginBy").val() == "NHQ Exam") {
            $("#btnSubmit").attr("href", "Exam/Dashboard.html")
        } else if ($("#loginBy").val() == "Examiner") {
            $("#btnSubmit").attr("href", "Examiner/Dashboard.html")
        }
    });

    $(".haveAadharOpt").change(function () {
        if ($(".haveAadharOpt").val() == "Yes") {
            $(".haveAadharShow").show()
            $(".noAadharShow").hide()
        } else if ($(".haveAadharOpt").val() == "No") {
            $(".noAadharShow").show()
            $(".haveAadharShow").hide()
        }
    });

    $('input[type=radio][name=mobileNumber]').change(function () {
        if (this.value == '1') {
            $(".sameAsAadhaarCard").show();
            $(".addAnotherNumber").hide();
        }
        else  {
            $(".addAnotherNumber").show();
            $(".sameAsAadhaarCard").hide();
        }
    });

    $('input[type=checkbox][name=dontAadhaar]').change(function () {
        if ($(this).is(':checked')) {
            $(".dontAadhaarHide").hide();
            $(".dontAadhaarShow").show();
        }
        else  {
            $(".dontAadhaarHide").show();
            $(".dontAadhaarShow").hide();
        }
    });

    $('input[type=checkbox][name=fastTrackCategory]').change(function () {
        if ($(this).is(':checked')) {
            $(".fastTrackCategoryShow").show();
        }
        else  {
            $(".fastTrackCategoryShow").hide();
        }
    });

    $(".selectCertifications").change(function () {
        if ($(".haveAadharOpt").val() == "Yes") {
            $(".haveAadharShow").show()
            $(".noAadharShow").hide()
        } else if ($(".haveAadharOpt").val() == "No") {
            $(".noAadharShow").show()
            $(".haveAadharShow").hide()
        }
    });

    $(".selectCertifications").change(function () {
        if ($(".selectCertifications").val() == "Senior Professional") {
            $(".seniorProfessionalBtn").show()
            $(".voucherBtn").hide()
        } else if ($(".selectCertifications").val() == "Voucher") {
            $(".seniorProfessionalBtn").hide()
            $(".voucherBtn").show()
        } else if ($(".selectCertifications").val() == "Medallion") {
            $(".seniorProfessionalBtn").hide()
            $(".voucherBtn").show()
        } else if ($(".selectCertifications").val() == "Label") {
            $(".seniorProfessionalBtn").hide()
            $(".voucherBtn").show()
        } else if ($(".selectCertifications").val() == "Choose...") {
            $(".seniorProfessionalBtn").hide()
            $(".voucherBtn").hide()
        }
    });



});