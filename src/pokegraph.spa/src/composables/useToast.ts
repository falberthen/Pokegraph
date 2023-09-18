import { useToast } from "vue-toastification";

export enum ToastMessageType {
  Success,
  Info,
  Error
}
export default function useToastNotification(messageType: ToastMessageType, message: string) {
  const toast = useToast();
  switch(messageType) {
    case ToastMessageType.Success:{
      toast.success(message);
      break;
    }
    case ToastMessageType.Info:{
      toast.info(message);
      break;
    }   
    case ToastMessageType.Error: {
      toast.error(message);
      break;
    }      
    default:
      break;
  }
}