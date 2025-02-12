﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Navigation.Master" AutoEventWireup="true" CodeBehind="FormStatic.aspx.cs" Inherits="Project_UI.FormStatic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container w-75 fs-3">
        <header class="display-1 d-flex justify-content-center alert">
            FEEDBACK FORM
        </header>
    <p class="card-text">Q1: Has the Teacher covered entire Syllabus as prescibed by University ?</p>
    <asp:RadioButtonList runat="server" CssClass="form-check" ID="R1">
        <asp:ListItem Value="5">Excellent</asp:ListItem>
        <asp:ListItem Value="4">Very Good</asp:ListItem>
        <asp:ListItem Value="3">Good</asp:ListItem>
        <asp:ListItem Value="2">Poor</asp:ListItem>
        <asp:ListItem Value="1">Very Poor </asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <p class="card-text">Q2: Has the Teacher covered relevant topics beyoud syllabus Syllabus ?</p>

    <asp:RadioButtonList runat="server" CssClass="form-check" ID="R2">
        <asp:ListItem Value="5">Excellent</asp:ListItem>
        <asp:ListItem Value="4">Very Good</asp:ListItem>
        <asp:ListItem Value="3">Good</asp:ListItem>
        <asp:ListItem Value="2">Poor</asp:ListItem>
        <asp:ListItem Value="1">Very Poor </asp:ListItem>
    </asp:RadioButtonList>
    <br />

    <p class="card-text">Q3: (a). Effectiveness of the teacher in terms of : Teaching Content / Course Content</p>

    <asp:RadioButtonList runat="server" CssClass="form-check" ID="R3">
        <asp:ListItem Value="5">Excellent</asp:ListItem>
        <asp:ListItem Value="4">Very Good</asp:ListItem>
        <asp:ListItem Value="3">Good</asp:ListItem>
        <asp:ListItem Value="2">Poor</asp:ListItem>
        <asp:ListItem Value="1">Very Poor </asp:ListItem>
    </asp:RadioButtonList>
    <br />

    <p class="card-text">Q4: (b). Effectiveness of the teacher in terms of : Communication Skills</p>

    <asp:RadioButtonList runat="server" CssClass="form-check" ID="R4">
        <asp:ListItem Value="5">Excellent</asp:ListItem>
        <asp:ListItem Value="4">Very Good</asp:ListItem>
        <asp:ListItem Value="3">Good</asp:ListItem>
        <asp:ListItem Value="2">Poor</asp:ListItem>
        <asp:ListItem Value="1">Very Poor </asp:ListItem>
    </asp:RadioButtonList>
    <br />

    <p class="card-text">Q5: (c). Effectiveness of the teacher in terms of : Use of teaching aids</p>

    <asp:RadioButtonList runat="server" CssClass="form-check" ID="R5">
        <asp:ListItem Value="5">Excellent</asp:ListItem>
        <asp:ListItem Value="4">Very Good</asp:ListItem>
        <asp:ListItem Value="3">Good</asp:ListItem>
        <asp:ListItem Value="2">Poor</asp:ListItem>
        <asp:ListItem Value="1">Very Poor </asp:ListItem>
    </asp:RadioButtonList>
    <br />

    <p class="card-text">Q6: Pace of which contents are covered</p>

    <asp:RadioButtonList runat="server" CssClass="form-check" ID="R6">
        <asp:ListItem Value="5">Excellent</asp:ListItem>
        <asp:ListItem Value="4">Very Good</asp:ListItem>
        <asp:ListItem Value="3">Good</asp:ListItem>
        <asp:ListItem Value="2">Poor</asp:ListItem>
        <asp:ListItem Value="1">Very Poor </asp:ListItem>
    </asp:RadioButtonList>
    <br />

    <p class="card-text">Q7: Motivation and inspiration for students to learn</p>

    <asp:RadioButtonList runat="server" CssClass="form-check" ID="R7">
        <asp:ListItem Value="5">Excellent</asp:ListItem>
        <asp:ListItem Value="4">Very Good</asp:ListItem>
        <asp:ListItem Value="3">Good</asp:ListItem>
        <asp:ListItem Value="2">Poor</asp:ListItem>
        <asp:ListItem Value="1">Very Poor </asp:ListItem>
    </asp:RadioButtonList>
    <br />

    <p class="card-text">Q8: (i). Support for the development of Students’ skill: Practical Demonstration</p>
    <asp:RadioButtonList runat="server" CssClass="form-check" ID="R8">
        <asp:ListItem Value="5">Excellent</asp:ListItem>
        <asp:ListItem Value="4">Very Good</asp:ListItem>
        <asp:ListItem Value="3">Good</asp:ListItem>
        <asp:ListItem Value="2">Poor</asp:ListItem>
        <asp:ListItem Value="1">Very Poor </asp:ListItem>
    </asp:RadioButtonList>
    <br />

    <p class="card-text">Q9: (ii). Support for the development of Students’ skill: Hands on training</p>

    <asp:RadioButtonList runat="server" CssClass="form-check" ID="R9">
        <asp:ListItem Value="5">Excellent</asp:ListItem>
        <asp:ListItem Value="4">Very Good</asp:ListItem>
        <asp:ListItem Value="3">Good</asp:ListItem>
        <asp:ListItem Value="2">Poor</asp:ListItem>
        <asp:ListItem Value="1">Very Poor </asp:ListItem>
    </asp:RadioButtonList>
    <br />

    <p class="card-text">Q10: Clarity of expectations of students</p>

    <asp:RadioButtonList runat="server" CssClass="form-check" ID="R10">
        <asp:ListItem Value="5">Excellent</asp:ListItem>
        <asp:ListItem Value="4">Very Good</asp:ListItem>
        <asp:ListItem Value="3">Good</asp:ListItem>
        <asp:ListItem Value="2">Poor</asp:ListItem>
        <asp:ListItem Value="1">Very Poor </asp:ListItem>
    </asp:RadioButtonList>
    <br />

    <p class="card-text">Q11: Feedback provided on Students’ progress</p>

    <asp:RadioButtonList runat="server" CssClass="form-check" ID="R11">
        <asp:ListItem Value="5">Excellent</asp:ListItem>
        <asp:ListItem Value="4">Very Good</asp:ListItem>
        <asp:ListItem Value="3">Good</asp:ListItem>
        <asp:ListItem Value="2">Poor</asp:ListItem>
        <asp:ListItem Value="1">Very Poor </asp:ListItem>
    </asp:RadioButtonList>
    <br />

    <p class="card-text">Q12: Willingness to offer help and advice to students</p>
    <asp:RadioButtonList runat="server" CssClass="form-check" ID="R12">
        <asp:ListItem Value="5">Excellent</asp:ListItem>
        <asp:ListItem Value="4">Very Good</asp:ListItem>
        <asp:ListItem Value="3">Good</asp:ListItem>
        <asp:ListItem Value="2">Poor</asp:ListItem>
        <asp:ListItem Value="1">Very Poor </asp:ListItem>
    </asp:RadioButtonList>
    <br />
        <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-dark btn-lg  mb-5 w-100" OnClick="Button1_Click"/>
    </div>
</asp:Content>
