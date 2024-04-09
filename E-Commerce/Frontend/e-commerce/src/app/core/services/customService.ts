import { environment } from "src/environments/environment.development";

export abstract class CustomService{
    protected apiPath:string = environment.apiPath;
}