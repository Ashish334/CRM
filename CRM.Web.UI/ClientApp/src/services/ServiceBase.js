import { Ui } from "../Ui";
import Result from "../models/Result";
import Axios, { AxiosRequestConfig } from "axios";
import { transformUrl } from "domain-wait";
import jsonToUrl from "json-to-url";
import { isNode } from "../utils";
import Globals from "../Globals";

/**
 * Represents base class of the isomorphic service.
 */
export default class ServiceBase {

  /**
   * Make request with JSON data.
   * @param opts
   */
  static async requestJson(opts) {

    var axiosResult = null;
    var result = null;

    opts.url = process.env.REACT_APP_BASE_URL + opts.url; // Allow requests also for the Node.

    var processQuery = (url, data) => {
      if (data) {
        return `${url}?${jsonToUrl(data)}`;
      }
      return url;
    };

    var axiosRequestConfig;

    if (isNode()) {
      // Make SSR requests 'authorized' from the NodeServices to the web server.
      axiosRequestConfig = {
        headers: {
          Cookie: Globals.getSession().private.cookie
        }
      }
    }
    if (opts.url.split("/").some(service => service === "download-report")) {
      axiosRequestConfig = {
        headers: {
          'Content-Type': 'application/json',
          'client_id': process.env.REACT_APP_CLIENT_ID,
          'Access-Control-Allow-Origin': '*',
          'Access-Control-Allow-Credentials': 'true',
          'Authorization': localStorage.getItem('token'),
          'responseType': 'application/vnd.ms-excel'
        }
      };
    }
    else if (opts.url.split("/").some(service => service === "auth")) {
      axiosRequestConfig = {
        headers: {
          'Content-Type': 'application/json',
          'client_id': process.env.REACT_APP_CLIENT_ID,
          'client_secret': process.env.REACT_APP_CLIENT_SECRET,
          'grant_type': 'password',
          'Access-Control-Allow-Origin': '*',
          'Access-Control-Allow-Credentials': 'true'
        }
      };
    }
    else {
      axiosRequestConfig = {
        headers: {
          'Content-Type': 'application/json',
          'client_id': process.env.REACT_APP_CLIENT_ID,
          'Access-Control-Allow-Origin': '*',
          'Access-Control-Allow-Credentials': 'true',
          'Authorization': localStorage.getItem('token')
        }
      };
    }

    try {
      switch (opts.method) {
        case "GET":
          axiosResult = await Axios.get(processQuery(opts.url, opts.data), axiosRequestConfig);
          break;
        case "POST":
          axiosResult = await Axios.post(opts.url, opts.data, axiosRequestConfig);
          break;
        case "PUT":
          axiosResult = await Axios.put(opts.url, opts.data, axiosRequestConfig);
          break;
        case "PATCH":
          axiosResult = await Axios.patch(opts.url, opts.data, axiosRequestConfig);
          break;
        case "DELETE":
          axiosResult = await Axios.delete(processQuery(opts.url, opts.data), axiosRequestConfig);
          break;
      }
      if (axiosResult.data.errors == undefined)
        result = new Result(axiosResult.data, axiosResult.headers, null);
      else {
        result = new Result(axiosResult.data, null, ...axiosResult.data.errors);
        console.log(...axiosResult.data.errors)
      }
    } catch (error) {
      //console.log(error);
      //console.log(error.response);
      //console.log(error.response.status);
      if (error.response == undefined) {
        result = new Result(null, null, error.message);
      }
      if (error.response.status == "401") {
        localStorage.clear();
        window.location.assign('/#/login');
      }
    
      else if (error.response.data.msg != undefined) {
        result = new Result(null, null, error.response.data.msg);
      }
      else if (opts.showError == undefined) {
        result = new Result(null, null, "Server Error");
      }

    }

    if (result.hasErrors && opts.showError == undefined) {
      Ui.showErrors(...result.errors);
    }

    return result;
  }

  /**
   * Allows you to send files to the server.
   * @param opts
   */
  static async sendFormData(opts) {
    var axiosResult = null;
    var result = null;

    opts.url = transformUrl(opts.url); // Allow requests also for Node.

    var axiosOpts = {
      headers: {
        'Content-Type': 'multipart/form-data'
      }
    };

    try {
      switch (opts.method) {
        case "POST":
          axiosResult = await Axios.post(opts.url, opts.data, axiosOpts);
          break;
        case "PUT":
          axiosResult = await Axios.put(opts.url, opts.data, axiosOpts);
          break;
        case "PATCH":
          axiosResult = await Axios.patch(opts.url, opts.data, axiosOpts);
          break;
      }
      result = new Result(axiosResult.data.value, ...axiosResult.data.errors);
    } catch (error) {
      result = new Result(null, error.message);
    }

    if (result.hasErrors) {
      Ui.showErrors(...result.errors);
    }

    return result;
  }
}
