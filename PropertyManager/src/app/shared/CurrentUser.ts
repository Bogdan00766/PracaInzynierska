import { HttpClient } from "@angular/common/http";

export abstract class CurrentUser {
  public static id: number = -1;
  public static email: string = "";
  public static userName: string = "";

}
